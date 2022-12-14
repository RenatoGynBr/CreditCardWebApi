using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardWebApi.Models
{
    public class CreditCard
    {
        [Key]
        public int CardId { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        public string CardNumber { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string CVV { get; set; }
        public string Token { get; set; }

        public int CustomerId { get; set; }
        //public virtual Customer Customer { get; set; }
    }
}
