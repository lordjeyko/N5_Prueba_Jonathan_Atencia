namespace N5_Data.Negocio.Implementacion
{
    using Microsoft.EntityFrameworkCore;
    using N5_Data.Entidades.Empleados;
    using N5_Data.Entidades.Perfiles;

    public class DB_Contexto: DbContext
    {
        public DB_Contexto(DbContextOptions<DB_Contexto> opc): base(opc) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(opt => opt.CommandTimeout(9000));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Perfiles)
                .WithMany(e => e.Usuarios)
                .UsingEntity<PerfilUsuario>();
            //.UsingEntity(
            //    "Perfiles",
            //    l => l.HasOne(typeof(Rol)).WithMany().HasForeignKey("PermisosId").HasPrincipalKey(nameof(Rol.uId)),
            //    r => r.HasOne(typeof(Empleado)).WithMany().HasForeignKey("UsuarioId").HasPrincipalKey(nameof(Empleado.uId)),
            //    j => j.HasKey("PermisosId", "UsuarioId"));
        }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<TipoRol> TipoRol { get; set; }
        public DbSet<PerfilUsuario> PerfilesDeUsuario { get; set; }

    }
}
