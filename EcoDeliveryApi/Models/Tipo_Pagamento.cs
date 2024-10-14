
using System.ComponentModel.DataAnnotations;

public class TipoPagamento{

    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; }
}