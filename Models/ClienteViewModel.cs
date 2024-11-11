using System.Collections.Generic;
using ReserveSystem.Models;

namespace ReserveSystem.Models
{
    public class ClienteViewModel
    {
        // Lista de clientes a serem exibidos na view
        public List<Cliente> Clientes { get; set; }

        // Página atual da paginação
        public int CurrentPage { get; set; }

        // Total de páginas para paginação
        public int TotalPages { get; set; }
    }
}
