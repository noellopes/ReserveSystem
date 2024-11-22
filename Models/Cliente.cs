using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; } // PK

        [Required]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string ClientName { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Phone")]
        public string ClientPhone { get; set; }

        [StringLength(200)]
        [Display(Name = "Address")]
        public string ClientAddress { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        [Display(Name = "Email")]
        public string ClientEmail { get; set; }

        [StringLength(20)]
        [Display(Name = "NIF")]
        public string ClientNIF { get; set; }

        [Display(Name = "Login Status")]
        public bool ClientLogin { get; set; }

        [Display(Name = "Active Booking Status")]
        public bool ClientStatus { get; set; }

        public ICollection<Client>? ReserveSystem { get; set; }

    }
}
