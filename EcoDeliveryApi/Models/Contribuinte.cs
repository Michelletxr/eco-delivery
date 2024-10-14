
using System.ComponentModel.DataAnnotations;

public class Contribuinte{

    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O endereço é obrigatório.")]
    public string Endereco { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório.")]
    [Phone(ErrorMessage = "O número de telefone não é válido.")]
    public string Telefone { get; set; }
}