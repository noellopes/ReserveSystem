using Microsoft.AspNetCore.Mvc.Rendering;
using ReserveSystem.Models;

namespace ReserveSystem.ViewModels
{
    public class JobViewModel
    {
        public IEnumerable<Job>? Jobs { get; set; }
        public SelectList? JobIds { get; set; }
        public int? Job_ID { get; set; }
        public string? Job_Name { get; set; }
        public int? SearchInt { get; set; }
        public PagingInfo? PagingInfo { get; set; }
    }
}
