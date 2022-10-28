using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;//agregado
using Funko.Models;
using Funko.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;


namespace Funko.Controllers
{
    public class catalogoController: Controller
    {
        private readonly ILogger<catalogoController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public catalogoController(ApplicationDbContext context,ILogger<catalogoController> logger,UserManager<IdentityUser> userManager){
            _context = context;
            _logger = logger;
            _userManager= userManager;
        } 
        public async Task<IActionResult> Index(string? searchString,string? searchString2){
            
            var producto = from o in _context.Datacatalogo select o;

            if(!String.IsNullOrEmpty(searchString)){

                producto =producto.Where( s => s.Name.Contains(searchString));
            }
             producto =producto.Where( s => s.Status.Contains("A"));

             if(!String.IsNullOrEmpty(searchString2)){

                producto =producto.Where( s => s.Categoria.Contains(searchString2));
            }
             producto =producto.Where( s => s.Status.Contains("A"));

            return View(await producto.ToListAsync());
        }

        
         public async Task<IActionResult> Details(int? id){
            catalogo objProduct = await _context.Datacatalogo.FindAsync(id);
            if(objProduct == null){
                return NotFound();
            }
            return View(objProduct);
        }


        public async Task<IActionResult> Add(int? id){
            var userID = _userManager.GetUserName(User);
            if(userID == null){
                ViewData["Message"] ="Por favor debe loguearse antes de agregar un producto";
                List<catalogo> productos = new List<catalogo>();
                return View("Index",productos);
            }else{
                var producto = await _context.Datacatalogo.FindAsync(id);
                Proforma proforma =new Proforma();                
                proforma.Producto = producto;
                proforma.Precio=producto.Precio;
                proforma.Cantidad=1;
                proforma.UserID=userID;
                _context.Add(proforma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
        
    }
}