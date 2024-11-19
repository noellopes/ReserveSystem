using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Job
    {
        public required int JobID { get; set; }
        public required string JobName { get; set; }
        public required string JobDescription { get; set; }

        public ICollection<RoomService>? RoomServices { get; set; }
        public ICollection<Staff>? Staffs { get; set; }
        // Methods for reference only, business logic should be in the controller
        
        /* public void consultJob()
        {
            // Consults the job
        }

        public void selectJob()
        {
            // Selects the job
        } */
    }
}