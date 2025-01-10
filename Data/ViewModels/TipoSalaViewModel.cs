namespace ReserveSystem.Models.ViewModels;

public class TipoSalaViewModel
{
    public IEnumerable<TipoSala> TipoSalas { get; set; } = new List<TipoSala>();
    public PagingInfo Pagination { get; set; } = new PagingInfo();
    public int? MinCapacity { get; set; } 
    public int? MaxCapacity { get; set; }
    
    public int? MinRoomSize { get; set; }
    public int? MaxRoomSize { get; set; }
    
    public double? MinHourlyPrice { get; set; }
    public double? MaxHourlyPrice { get; set; }
}