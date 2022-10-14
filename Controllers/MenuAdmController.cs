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
    public class MenuAdmController:Controller
    {
        private readonly ILogger<MenuAdmController> _logger;
        
        private readonly ApplicationDbContext _context;
        public MenuAdmController(ApplicationDbContext context,ILogger<MenuAdmController> logger){
            _context = context;
            _logger = logger;
            
        }

        public IActionResult Index(){
            return View();
        }

    }
}