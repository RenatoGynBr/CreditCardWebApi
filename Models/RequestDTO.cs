using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardWebApi.Models
{
    public class Request2DTO
    {
        public int CustomerId { get; set; }
        public int CardId { get; set; }
        public string Token { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string CVV { get; set; }
    }
}
