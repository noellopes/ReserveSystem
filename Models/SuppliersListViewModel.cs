using System.Collections.Generic;
using ReserveSystem.Models;

namespace ReserveSystem.ViewModels
{
    public class SuppliersListViewModel
    {
        public IEnumerable<Supplier> Supplier { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}