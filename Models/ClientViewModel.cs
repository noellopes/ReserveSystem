namespace ReserveSystem.Models
{
    public class ClientViewModel
    {
        public IEnumerable<ClientModel> clientModels { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
