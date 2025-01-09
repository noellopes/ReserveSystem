using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace ReserveSystem.Models
{
    public class Job
    {
        [Key]
        public int Job_ID { get; set; }

        [Required, Display(Name = "Name"), StringLength(150)]
        public string Job_Name { get; set; }

        [Display(Name = "Description"), StringLength(350)]
        public string? Job_Description { get; set; }

    }
}
