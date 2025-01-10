namespace ReserveSystem.Models
{
    public class TQePrecosViewModel
    {
        public IEnumerable<TQePreco> TQePrecos { get; set; }
        public TQePrecosPageInfo TQePrecosPageInfos { get; set; }

        public string SearchRoomType { get; set; }
    }
}
