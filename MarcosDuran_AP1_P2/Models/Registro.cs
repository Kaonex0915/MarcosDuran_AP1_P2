using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarcosDuran_AP1_P2.Models
{
    public class Registro
    {
        [Key]
        public int RegistroId { get; set; }
        [Required(ErrorMessage = "Es necesario el campo Nombre")]
        public string Nombres { get; set; }
   
  
    }
}
