using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Funko.Models
{
    [Table("t_pago")]
    public class Pago
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("PaymentDate")]
        public DateTime PaymentDate { get; set; }
        [Column("NombreTarjeta")]
        public String NombreTarjeta { get; set; }
        [Column("NumeroTarjeta")]
        public String NumeroTarjeta { get; set; }

        [NotMapped]
        public String DueDateYYMM { get; set; }
        [NotMapped]
        public String Cvv { get; set; }

        
        [Column("MontoTotal")]
        public Decimal MontoTotal{ get; set; }
        [Column("UserID")]
        public String UserID{ get; set; }

    }
}