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
        public async Task<IActionResult> Index(string? searchString){
            
            var producto = from o in _context.Datacatalogo select o;

            if(!String.IsNullOrEmpty(searchString)){

                producto =producto.Where( s => s.Name.Contains(searchString));
            }
             producto =producto.Where( s => s.Status.Contains("A"));

            return View(await producto.ToListAsync());
        }
        
    }
}