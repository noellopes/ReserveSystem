namespace ReserveSystem.Models
{
    public class EquipamentoViewModel
    {
        public List<Equipamento> Equipamentos { get; set; }
        public Paginacao Paginacao { get; set; }
        public string FilterNomeEquipamento { get; set; }
    }
}
