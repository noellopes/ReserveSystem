namespace ReserveSystem.Models
{
    public class EquipamentoViewModel
    {
        public List<Equipamento> Equipamentos { get; set; }
        public List<TipoEquipamento> TipoEquipamento { get; set; }
        public Paginacao Paginacao { get; set; }
        public string FilterNomeEquipamento { get; set; }
        public string FilterTipoEquipamento { get; set; }
    }
}
