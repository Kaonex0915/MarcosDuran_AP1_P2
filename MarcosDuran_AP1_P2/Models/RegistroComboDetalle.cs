using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarcosDuran_AP1_P2.Models;

public class RegistroComboDetalle
{
    [Key]
    public int DetalleId { get; set; }

    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public int ComboId { get; set; }


    [ForeignKey("ComboId")]
    public RegistroCombo? registroCombo { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public int ArticuloId { get; set; }

    [ForeignKey("ArticuloId")]
    public Articulos? Articulos { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public int Costo { get; set; }

}
