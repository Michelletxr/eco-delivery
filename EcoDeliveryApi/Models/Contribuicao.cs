using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public enum StatusEnum
{
    PENDENTE = 1,
    RECEBIDO = 2,
    CANCELADO = 3
}

public class Contribuicao{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "")]
    public Double valor { get; set; } = 0;

    [ForeignKey("TipoPagamentoId")]
    public TipoPagamento TipoPagamento{ get; set; }

    [ForeignKey("ContribuinteId")]
    public Contribuinte Contribuinte{ get; set; }

    [Required(ErrorMessage = "")]
    public DateTime Data_Prevista { get; set; }

    public DateTime Data_Recebimento { get; set; }

    public StatusEnum Status { get; set; } = StatusEnum.PENDENTE;

    public static string StatusMapper(StatusEnum Status){

        switch (Status){
            case StatusEnum.RECEBIDO:
                return "Recebido";
            case StatusEnum.CANCELADO:
                return "Cancelado";
            default: return "Pendente";
        }
    }

    public static StatusEnum GetStatusEnum(int statusId){
        switch (statusId){
            case 2:
                return StatusEnum.RECEBIDO;
            case 3:
                return StatusEnum.CANCELADO;
            default: return StatusEnum.PENDENTE;
        }
    }


}





  