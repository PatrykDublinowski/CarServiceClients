using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceClients.Model
{
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }

        [Required]
        [Display(Name = "Data utworzenia")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreateDate { get; set; }

        [Required]
        [Display(Name = "Data ostatniej edycji")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime LastEditDate { get; set; }

        [Required]
        [Display(Name = "Status")]
        public Status Status { get; set; }

        [Required]
        [Display(Name = "Opis")]
        [StringLength(255)]
        public string Description { get; set; }

        [Display(Name = "Koszt usługi")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }

        [Display(Name = "Opłacone")]
        public NoYes IsPaid { get; set; }

        [Display(Name = "Data opłacenia")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? PaymentDate { get; set; } = null;

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("Client")]
        public int ClientID { get; set; }
        public Client Client { get; set; }
    }
}
