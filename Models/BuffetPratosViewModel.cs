using System.Collections.Generic;
using ReserveSystem.Models;

namespace ReserveSystem.ViewModels
{
    public class BuffetPratosViewModel
    {
        public Buffet Buffet { get; set; }
        public List<Prato> AvailablePratos { get; set; }
        public int SelectedPratoId { get; set; } // Para selecionar um prato para adicionar
    }
}
