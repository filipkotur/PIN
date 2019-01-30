using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_PIN.Models
{
    public class Dugovi
    {   
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Banka { get; set; }
        public double Iznos { get; set; }
        public string OIB { get; set; }
        [Display(Name = "Datum rođenja")]
        [DataType(DataType.Date)]
        public DateTime DatumRođenja { get; set; }
        [Display(Name = "Adresa Stanovanja")]
        public string AdresaStanovanja { get; set; }
        [Display(Name = "Kontakt Broj")]
        public string KontaktBroj { get; set; }
    }
}
