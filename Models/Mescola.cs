using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Mescola
    {
        public int Id { get; set; }


        [StringLength(200, ErrorMessage = "La descrizione non può superare i 200 caratteri.")]
        public string Descrizione { get; set; }

        [Required(ErrorMessage = "Inserire la data di produzione è obbligatorio!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data di Produzione")]
        public DateTime DataProduzione { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Il prezzo deve essere maggiore di 0.")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Prezzo { get; set; }
    }
}

