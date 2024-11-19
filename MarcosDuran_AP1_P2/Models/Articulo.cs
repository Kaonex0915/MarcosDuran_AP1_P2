using System.ComponentModel.DataAnnotations;

namespace MarcosDuran_AP1_P2.Models;

public class Articulos
{
    [Key]
    public int ArticuloId { get; set; }

    public string? Descripcion { get; set; }

    public int Costo { get; set; }

    public int Precio { get; set; }

    public int Existencia { get; set; }
}