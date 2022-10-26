using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Funko.Models;//agrgado

namespace Funko.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    
    }
    public DbSet<Funko.Models.catalogo> Datacatalogo { get; set; }
    public DbSet<Funko.Models.Proforma> DataProforma { get; set; }
    public DbSet<Funko.Models.Pago> DataPago { get; set;}
    public DbSet<Funko.Models.Pedido> DataPedido { get; set; }
    public DbSet<Funko.Models.DetallePedido> DataDetallePedido { get; set; }

   public DbSet<Funko.Models.Contacto> DataContactos { get; set; }
    
}
