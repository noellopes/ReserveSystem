using System.Collections.Generic;
using ReserveSystem.Models;

namespace ReserveSystem.ViewModels
{
    public class BuffetListViewModel
    {
        public List<Buffet> Buffets { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
