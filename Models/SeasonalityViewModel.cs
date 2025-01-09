namespace ReserveSystem.Models
{
    public class SeasonalityViewModel
    {
        public IEnumerable<Sazonalidade> Sazonalidades { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string SearchName { get; set; }
        public DateOnly? SearchDate { get; set; }
    }
}
