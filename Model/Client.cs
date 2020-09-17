using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceClients.Model
{
    public class Client
    {
        public Client()
        {
            Cars     = new List<Car>();
            Services = new List<Service>();
        }

        [Key]
        public int ClientID { get; set; }

        [Required]
        [Display(Name = "Imię")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Adres")]
        [StringLength(50)]
        public string Adress { get; set; }

        [Required]
        [Display(Name = "Kod pocztowy")]
        [StringLength(6)]
        public string PostCode { get; set; }

        [Required]
        [Display(Name = "Miasto")]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [Display(Name = "Mail")]
        [StringLength(50)]
        public string Mail { get; set; }

        [Required]
        [Display(Name = "Telefon")]
        [StringLength(50)]
        public string Phone { get; set; }

        [Display(Name = "NIP")]
        [StringLength(50)]
        public string NIP { get; set; }

        [Required]
        [Display(Name = "Wszystko opłacone")]
        public NoYes AllPaid {get; set;}

        public List<Car> Cars { get; set; }
        public List<Service> Services { get; set; }

        [NotMapped]
        [Display(Name = "Nazwa klienta")]
        public string GetFullName => FirstName + " " + LastName;
    }
}
