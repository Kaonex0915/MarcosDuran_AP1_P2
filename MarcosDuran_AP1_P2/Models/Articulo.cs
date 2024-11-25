using System.ComponentModel.DataAnnotations;

namespace MarcosDuran_AP1_P2.Models;

public class Articulos
{
    [Key]
    public int ArticuloId { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]

    [StringLength(75, MinimumLength = 3, ErrorMessage = "El campo {0} debe de tener entre {2} y {1} caracteres")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public int Costo { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public int Precio { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public int Existencia { get; set; }
}