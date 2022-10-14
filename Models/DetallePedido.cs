using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Funko.Models
{
    [Table("t_order_detail")]
    public class DetallePedido
    {    
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID {get; set;}
        [Column("Producto")]
        public catalogo Producto {get; set;}
        [Column("Cantidad")]
        public int Cantidad{get; set;}
        [Column("Precio")]
        public Decimal Precio { get; set; }
        [Column("pedidoA")]
        public Pedido pedido {get; set;}


    }
}