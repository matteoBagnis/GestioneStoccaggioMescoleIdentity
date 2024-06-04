using System.ComponentModel.DataAnnotations;

namespace GestioneStoccaggioMescoleIdentity.Models
{
    public class Cliente
    {
        [Key]
        public int ID { get; set; }


        [Required(ErrorMessage = "Inserire il nome è obbligatorio!.")]
        [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Inserire il cognome è obbligatorio!")]
        [StringLength(100, ErrorMessage = "Il cognome non può superare i 100 caratteri.")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Inserire l'email è obbligatorio!")]
        [StringLength(100, ErrorMessage = "L'email non può superare i 100 caratteri.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Inserire l'ID della ruota richiesta è obbligatorio!")]
        [StringLength(100, ErrorMessage = "L'ID della ruota richiesta non può superare i 100 caratteri.")]
        public string IDRuotaRichiesta { get; set; }
    }
}