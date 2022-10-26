using Microsoft.AspNetCore.Mvc;
using Funko.Models;
using Funko.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;
namespace Funko.Controllers
{
    public class ListaVentasController: Controller
     
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager; 
        public ListaVentasController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
        var items = from o in _context.DataPago select o;
        var datos = await items.ToListAsync();

        dynamic model = new ExpandoObject();
        model.elementosDatos = datos;
        
        return View(model);
        }

        public async Task<IActionResult> Details(int? id){

            Pedido objProduct = await _context.DataPedido.FindAsync(id);
            DetallePedido objProduct1 = await _context.DataDetallePedido.FindAsync(objProduct.ID);

            var items = from o in _context.DataDetallePedido select o;
            items = items.Include(p => p.Producto).Include(p => p.pedido).Where(w => w.pedido.ID.Equals(objProduct.ID));


            var carrito = await items.ToListAsync();
            var total= carrito.Sum(c => c.Cantidad + c.Cantidad);

            dynamic model = new ExpandoObject(); 
            model.montoTotal = total;
            model.elementosCarrito = carrito;

           // var mtoUsuarios = db.AspNetUsers;

            return View(model);

         }
        

    }
    
    
}