using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeDotnet.Models
{
    [Table("T_IMAGEM_USUARIO_ODONTOPREV")]
    public class Imagem
    {
        [Key]
        [Column("IMAGEM_USUARIO_ID")]
        public int ImagemUsuarioId { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        [Column("USUARIO_ID")]
        public int? UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

        [Column("IMAGEM_URL")]
        [StringLength(255)]
        [DataType(DataType.ImageUrl)]
        public string? ImagemUrl { get; set; }

        [Column("DATA_ENVIO")]
        public DateTime? DataEnvio { get; set; } = DateTime.Now;
    }
}
