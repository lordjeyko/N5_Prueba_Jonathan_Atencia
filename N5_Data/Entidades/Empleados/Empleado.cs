using N5_Data.Entidades.Perfiles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N5_Data.Entidades.Empleados
{
    [Table("Usuario")]
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public Guid uId { get; set; }

        [MaxLength(150)]
        [Column("Nombre")]
        public string cNombre { get; set; }

        [MaxLength(150)]
        [Column("Apellido")]
        public string cApellido { get; set; }

        [MaxLength(20)]
        [Column("Documento")]
        public string cDocumento { get; set; }

        [MaxLength(20)]
        [Column("Celular")]
        public string cCelular { get; set; }
        
        //public List<PerfilUsuario> PerfilUsuario { get; set; }

        public List<Rol> Perfiles { get; set; }
    }
}
