namespace ReserveSystem.Models.ViewModels;

public class SalaViewModel
{
    public IEnumerable<Sala> Salas { get; set; } = new List<Sala>(); 
    public PagingInfo Pagination { get; set; } = new PagingInfo();  
    public string? RoomTypeFilter { get; set; }   
    public TimeOnly? StartTimeFilter { get; set; } 
    public TimeOnly? EndTimeFilter { get; set; }  
    public int? FloorFilter { get; set; }  

}