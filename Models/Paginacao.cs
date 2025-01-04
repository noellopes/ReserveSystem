namespace ReserveSystem.Models
{
    public class Paginacao
    {
        public int ItemTotal { get; set; }
        public int TamanhoPagina { get; set; } = 10;
        public int PaginaCorrente { get; set; } = 1;
        public int PaginaMaximoVerAntesDepois { get; set; } = 4;
        public int PaginaTotal => (int)Math.Ceiling((double)ItemTotal / TamanhoPagina);
        public int PrimeiraPaginaVer => Math.Max(1, PaginaCorrente - PaginaMaximoVerAntesDepois);
        public int UltimaPaginaVer => Math.Min(PaginaTotal, PaginaCorrente + PaginaMaximoVerAntesDepois);

    }
}
