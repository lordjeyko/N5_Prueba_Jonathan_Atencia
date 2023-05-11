namespace N5_Configuracion
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using N5_Api.Configuracion.Proveedor;
    using N5_Data.Negocio.Implementacion;
    using N5_Data.Negocio.Interfaz;
    using System.Reflection;
    using System.Text;

    public class Configuracion
    {
        
        public Configuracion(IConfiguration configuration)
        {
            Config = configuration;
        }

        public IConfiguration Config { get; private set; }

        public void ConfigServicio(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(x => 
                x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

            services.AddDbContext<DB_Contexto>(opt => 
                opt.UseSqlServer(Config.GetConnectionString("defaultConnection")));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(cof =>
            {
                cof.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { 
                    Title = "WebApi_N5", 
                    Version ="v1",
                    Description = "Proyecto creado para la prueba solicitada por N5",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact { 
                        Email = "ing.atencia.barranco@gmail.com",
                        Name = "Jonathan Edgardo Atencia Barranco"
                        
                    }
                });

                var archivoXML = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var rutaXML = Path.Combine(AppContext.BaseDirectory, archivoXML);

                cof.IncludeXmlComments(rutaXML);

                cof.AddSecurityDefinition("Bearer", 
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                        Description = "Jwt utilizado para autorizar el ingreso"                        
                    });

                cof.AddSecurityRequirement(
                    new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                    {
                        {
                            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                            {
                                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                                {
                                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                    });
            });

            Console.WriteLine(Config["Jwt:Key"]);
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;

                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["Jwt:Key"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });
            services.AddAuthorization();


            Ejecutar(services);
        }

        public void ConfigApp(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }

        private void Ejecutar(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ConfiguracionMapeo));
            services.AddScoped<DB_Contexto>();
            services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();

            services.Registro();
        }
    }
}
