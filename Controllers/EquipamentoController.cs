using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Data;
using ReserveSystem.Models;
using System.Linq;

namespace ReserveSystem.Controllers
{
    public class EquipamentoController : Controller
    {
        private readonly ReserveSystemContext _context;

        public EquipamentoController(ReserveSystemContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (!_context.Equipamento.Any())
            {
                var listaEquipamentos = new List<Equipamento>
                {
                    new Equipamento { NomeEquipamento = "Projetor", TipoEquipamento = "Eletrônico", Quantidade = 3 }, 
                    new Equipamento { NomeEquipamento = "Sistema de Som", TipoEquipamento = "Eletrônico", Quantidade = 2 }, 
                    new Equipamento { NomeEquipamento = "Microfone", TipoEquipamento = "Eletrônico", Quantidade = 5 }, 
                    new Equipamento { NomeEquipamento = "Quadro Branco", TipoEquipamento = "Mobiliário", Quantidade = 3 }, 
                    new Equipamento { NomeEquipamento = "Mesa de Conferência", TipoEquipamento = "Mobiliário", Quantidade = 1 }
                };

                _context.Equipamento.AddRange(listaEquipamentos);
                _context.SaveChanges();
            }

            var equipamentos = _context.Equipamento.ToList(); 
            return View(equipamentos);
        }
    }
}
