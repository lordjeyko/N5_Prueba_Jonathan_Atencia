using N5_Data.Entidades.Empleados;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N5_Data.Entidades.Perfiles
{
    [Table("Perfiles")]
    public class PerfilUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public Guid uId { get; set; }

        public Guid UsuarioId { get; set; }
        [Column(Order = 1)]
        [ForeignKey("UsuarioId")]
        public Empleado uUsuarioId { get; set; } = null!;

        public Guid PermisosId { get; set; }
        [Column(Order = 2)]
        [ForeignKey("PermisosId")]
        public Rol uRolId { get; set; } = null!;
    }
}
