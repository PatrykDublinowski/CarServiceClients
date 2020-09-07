using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceClients.Model
{
    public class Employee
    {
        public Employee()
        {
            Services = new List<Service>();
        }

        [Key]
        public int EmployeeID { get; set; }

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

        [Required]
        [Display(Name = "Specjalizacja")]
        public Profession Profession { get; set; }

        [Required]
        [Display(Name = "Czy wolny")]
        public YesNo IsFree { get; set; }

        public List<Service> Services { get; set; }

        [NotMapped]
        [Display(Name = "Nazwa pracownika")]
        public string GetFullName => FirstName + " " + LastName;
    }
}
