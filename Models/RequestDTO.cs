using System.ComponentModel.DataAnnotations.Schema;

namespace CreditCardWebApi.Models
{
    public class RequestDTO
    {
        public int CustomerId { get; set; }
        public string CardNumber { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string CVV { get; set; }
    }

    public class Request2DTO
    {
        public int CustomerId { get; set; }
        public int CardId { get; set; }
        public string Token { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string CVV { get; set; }
    }

}
