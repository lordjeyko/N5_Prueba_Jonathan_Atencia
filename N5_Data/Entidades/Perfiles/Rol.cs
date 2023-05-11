namespace N5_Data.Entidades.Perfiles
{
    using N5_Data.Entidades.Empleados;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Permisos")]
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public Guid uId { get; set; }

        [MaxLength(150)]
        [Column("Nombre")]
        public string cNombre { get; set; }

        public List<TipoRol> TiposRol { get; set; }
        
        //public List<PerfilUsuario> PerfilUsuario { get; set; }
        public List<Empleado> Usuarios { get; set; }
    }
}
