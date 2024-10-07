using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChallengeDotnet.Dtos
{
    public class UsuarioChangeDataDto
    {
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [Column("CPF")]
        [StringLength(14)]
        public required string CPF { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [Column("nome")]
        [StringLength(100)]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O sobrenome é obrigatório.")]
        [Column("sobrenome")]
        [StringLength(255)]
        public required string Sobrenome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [Column("email")]
        [StringLength(255)]
        [EmailAddress]
        public required string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [Column("senha")]
        [StringLength(255)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public required string Senha { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [Column("data_nascimento")]
        public required DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O gênero é obrigatório.")]
        [Column("genero")]
        [StringLength(1)]
        public required string Genero { get; set; }

        [Column("data_cadastro")]
        public DateTime? DataCadastro { get; set; } = DateTime.Now;
    }
}
