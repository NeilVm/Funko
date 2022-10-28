using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;//agregado
using System.ComponentModel.DataAnnotations.Schema;

namespace Funko.Models
{
    [Table("t_producto")]
    public class catalogo
    {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
        public int Id {get;set;}
    [Column("Name")]
        public String Name { get; set; }
    [Column("Precio")]
        public Decimal Precio { get; set; }
    [Column("Descripcion")]
        public String Descripcion { get; set; }   
    [Column("ImagenName")]
         public String ImagenName { get; set; }
    [Column("Status")]
         public String Status { get; set; }   
    [Column("Categoria")]
         public String Categoria { get; set; }   
    }
    
    
}