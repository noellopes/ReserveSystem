using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{

    public class ClientViewModel
    {    
        public IEnumerable<ClientModel> ClientModels { get; set; }
      
        public Paginacao paginacao { get; set; }

        public string PesquisarEmail { get; set; }
        public string PesquisarNIF { get; set; }
    }
}
