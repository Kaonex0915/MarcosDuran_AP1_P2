﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarcosDuran_AP1_P2.Models;

public class RegistroComboDetalle
{
    [Key]
    public int DetalleId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;

    public int ComboId { get; set; }

    [ForeignKey("ComboId")]

    public int ArticuloId { get; set; }
    [ForeignKey("ArticuloId")]
    public int Cantidad { get; set; }

    public int Costo { get; set; }

    public ICollection<RegistroCombo> comboDetalle { get; set; } = new List<RegistroCombo>();
}