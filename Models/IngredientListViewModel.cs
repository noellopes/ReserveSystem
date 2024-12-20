using System.Collections.Generic;
using ReserveSystem.Models;

namespace ReserveSystem.ViewModels
{
    public class IngredientListViewModel
    {
        public IEnumerable<Ingredient> Ingredient { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
