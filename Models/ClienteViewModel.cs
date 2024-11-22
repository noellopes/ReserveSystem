using System;
using System.Collections.Generic;

namespace ReserveSystem.Models
{
    public class ClientViewModel
    {
        // Client object for displaying and editing a single client
        public List<Client> Clients { get; set; }

        public Client Client { get; set; }
        // Current page for pagination (if pagination is used)
        public int CurrentPage { get; set; }

        // Total number of pages for pagination (if pagination is used)
        public int TotalPages { get; set; }

        // Name for filtering clients
        public string SearchName { get; set; }
        public List<string> AllClientNames { get; set; } // Adicionado para dropdown
    }
}

