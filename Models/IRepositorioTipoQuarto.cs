namespace ReserveSystem.Models
{
    public interface IRepositorioTipoQuarto
    {
        public IEnumerable<TipoQuarto> TipoQuartos { get; }
    }
}
