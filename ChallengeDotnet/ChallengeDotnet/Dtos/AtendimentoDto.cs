using ChallengeDotnet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChallengeDotnet.Dtos
{
    public class AtendimentoDto
    {

        [Required]
        [ForeignKey("Usuario")]
        [Column("USUARIO_ID")]
        public int? UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

        [Required(ErrorMessage = "O nome do dentista é obrigatório.")]
        [Column("DENTISTA_NOME")]
        [StringLength(100)]
        public required string DentistaNome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O nome da clínica é obrigatório.")]
        [Column("CLINICA_NOME")]
        [StringLength(100)]
        public required string ClinicaNome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data do atendimento é obrigatória.")]
        [Column("DATA_ATENDIMENTO")]
        public required DateTime DataAtendimento { get; set; } = DateTime.Now;

        [Column("DESCRICAO_PROCEDIMENTO")]
        public string? DescricaoProcedimento { get; set; }

        [Column("CUSTO")]
        [DataType(DataType.Currency)]
        public decimal? Custo { get; set; }

        [Column("DATA_REGISTRO")]
        public required DateTime DataRegistro { get; set; } = DateTime.Now;

    }
}
