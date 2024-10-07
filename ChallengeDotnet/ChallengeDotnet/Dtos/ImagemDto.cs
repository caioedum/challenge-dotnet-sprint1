using ChallengeDotnet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChallengeDotnet.Dtos
{
    public class ImagemDto
    { 
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

