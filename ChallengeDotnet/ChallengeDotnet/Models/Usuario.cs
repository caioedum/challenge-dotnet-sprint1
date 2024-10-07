using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeDotnet.Models
{
    [Table("T_USUARIO_ODONTOPREV")]
    public class Usuario
    {
        
        [Key]
        [Column("USUARIO_ID")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [Column("CPF")]
        [StringLength(14)]
        public required string CPF { get; set; } = string.Empty;

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [Column("NOME")]
        [StringLength(100)]
        public required string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O sobrenome é obrigatório.")]
        [Column("SOBRENOME")] 
        [StringLength(255)]
        public required string Sobrenome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [Column("EMAIL")] 
        [StringLength(255)]
        [EmailAddress]
        public required string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [Column("SENHA")] 
        [StringLength(255)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public required string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [Column("DATA_NASCIMENTO")] 
        public required DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O gênero é obrigatório.")]
        [Column("GENERO")]
        [StringLength(1)]
        public required string Genero { get; set; } = string.Empty;

        [Column("DATA_CADASTRO")]
        public DateTime? DataCadastro { get; set; } = DateTime.Now;
    }
}
