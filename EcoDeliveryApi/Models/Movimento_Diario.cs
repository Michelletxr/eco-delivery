using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class MovimentoDiario{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "")]
    public DateTime Data_Movimento { get; set; }

    [ForeignKey("MensageiroId")]
    public Mensageiro Mensageiro { get; set; }

    [ForeignKey("ContribuicaoId")]
    public Contribuicao ContribuicaoRecibo { get; set; }

}