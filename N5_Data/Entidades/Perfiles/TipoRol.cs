namespace N5_Data.Entidades.Perfiles
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Tipo_Permisos")]
    public class TipoRol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public Guid uId { get; set; }

        [MaxLength(150)]
        [Column("Nombre")]
        public string cNombre { get; set; }

        [ForeignKey("PermisoId")]
        public Rol Rol { get; set; }
    }
}
