﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace MarcosDuran_AP1_P2.Models
{
    public class RegistroCombo
    {
        [Key]
        public int ComboId { get; set; }
        [Required(ErrorMessage = "Es necesario el campo Descripcion")]
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
    
        public int Precio { get; set; }

        public bool Vendido {  get; set; }
  
    }
}
