namespace ReserveSystem.Models
{
    public interface FakeRepositorioTipoQuarto: IRepositorioTipoQuarto
    {
        public IEnumerable<TipoQuarto> TipoQuartos => 
            new List<TipoQuarto>() 
            {
                new TipoQuarto { TipoQuartoId = 1, type = "Single Room", capacity = 1, RoomQuantity = 10, AcessibilityRoom = true, View = false }, 
                new TipoQuarto { TipoQuartoId = 2, type = "Double Room", capacity = 2, RoomQuantity = 15, AcessibilityRoom = true, View = true }, 
                new TipoQuarto { TipoQuartoId = 3, type = "Suite", capacity = 4, RoomQuantity = 5, AcessibilityRoom = false, View = true }, 
                new TipoQuarto { TipoQuartoId = 4, type = "Deluxe Room", capacity = 3, RoomQuantity = 8, AcessibilityRoom = false, View = false },
                new TipoQuarto { TipoQuartoId = 5, type = "Family Room", capacity = 5, RoomQuantity = 7, AcessibilityRoom = true, View = true },
                new TipoQuarto { TipoQuartoId = 6, type = "Executive Suite", capacity = 3, RoomQuantity = 4, AcessibilityRoom = false, View = true } 
            };
    }
}
