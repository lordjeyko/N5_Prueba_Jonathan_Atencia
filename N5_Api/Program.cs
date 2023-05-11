using N5_Configuracion;

var builder = WebApplication.CreateBuilder(args);

var startup = new Configuracion(builder.Configuration);
startup.ConfigServicio(builder.Services);

var app = builder.Build();
startup.ConfigApp(app);

app.Run();
