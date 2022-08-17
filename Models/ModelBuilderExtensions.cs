using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardWebApi.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder mb)
        {
            //mb.Entity<Customer>().HasData(
            //    new Customer { CustomerId = 1, CustomerName = "Bill Gates" },
            //    new Customer { CustomerId = 2, CustomerName = "Mark Zuckerberg" },
            //    new Customer { CustomerId = 3, CustomerName = "Elon Musk" }
            //    );

            mb.Entity<CreditCard>().HasData(
                new CreditCard { CardId = 1, CustomerId = 1, CardNumber = "4242424242424242", CVV = "123", Token = "" },
                new CreditCard { CardId = 2, CustomerId = 1, CardNumber = "1111222233334444", CVV = "222", Token = "" },
                new CreditCard { CardId = 3, CustomerId = 1, CardNumber = "4444333322221111", CVV = "333", Token = "" },
                new CreditCard { CardId = 4, CustomerId = 2, CardNumber = "7777888899991111", CVV = "444", Token = "" },
                new CreditCard { CardId = 5, CustomerId = 3, CardNumber = "9999888877776666", CVV = "555", Token = "" }
                );
        }
    }
}
