using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceClients.Model
{
    public class Car
    {
        [Key]
        public int CarID { get; set; }

        [Required]
        [Display(Name = "Marka")]
        [StringLength(50)]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Model")]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Data produkcji")]
        [DataType(DataType.Date)]
        public DateTime DateOfProducion { get; set; }

        [Required]
        [Display(Name = "Typ nadwozia")]
        public BodyType BodyType { get; set; }

        [Display(Name = "Kolor")]
        [StringLength(50)]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Pojemnosc silnika")]
        public float EngineCapacity { get; set; }

        [Display(Name = "Typ silnika")]
        [StringLength(50)]
        public string EngineType { get; set; }

        [Required]
        [Display(Name = "Typ paliwa")]
        public FuelType FuelType { get; set; }

        [Required]
        [Display(Name = "Numer rejestracyjny")]
        [StringLength(50)]
        public string PlateNumber { get; set; }

        [Required]
        [Display(Name = "Numer VIN")]
        [StringLength(50)]
        public string Vin { get; set; }

        [NotMapped]
        [Display(Name = "Nazwa samochodu")]
        public string GetCarDesc => Brand + " " + Model + " " + DateOfProducion;

        [ForeignKey("Client")]
        public int ClientID { get; set; }
        public Client Client { get; set; }
    }
}
