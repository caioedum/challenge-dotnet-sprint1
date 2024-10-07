using ChallengeDotnet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChallengeDotnet.Dtos
{
    public class PrevisaoDto
    {
        [Required]
        [ForeignKey("ImagemUsuario")]
        [Column("IMAGEM_USUARIO_ID")]
        public int? ImagemUsuarioId { get; set; }

        public Imagem? ImagemUsuario { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        [Column("USUARIO_ID")]
        public int? UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

        [Column("PREVISAO_TEXTO")]
        [StringLength(255)]
        public string PrevisaoTexto { get; set; } = string.Empty;

        [Column("PROBABILIDADE")]
        public float? Probabilidade { get; set; }

        [Column("RECOMENDACAO")]
        [StringLength(255)]
        public required string Recomendacao { get; set; } = string.Empty;

        [Column("DATA_PREVISAO")]
        public DateTime? DataPrevisao { get; set; } = DateTime.Now;
    }
}
