using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace MarcosDuran_AP1_P2.Models
{
    public class RegistroCombo
    {
        [Key]
        public int ComboId { get; set; }
        [Required(ErrorMessage = "Es necesario el campo Descripcion")]
        [StringLength(75, MinimumLength = 3, ErrorMessage = "El campo {0} debe de tener entre {2} y {1} caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Precio { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public bool Vendido { get; set; }

        public ICollection<RegistroComboDetalle> registroComboDetalle { get; set; } = new List<RegistroComboDetalle>();
    }
}
