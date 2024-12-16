using System.Collections.Generic;
using ReserveSystem.Models;

namespace ReserveSystem.ViewModels
{
    public class PratoListViewModel
    {
        public IEnumerable<Prato> Pratos { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
