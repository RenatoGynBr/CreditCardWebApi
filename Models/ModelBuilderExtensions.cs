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
            mb.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, CustomerName = "Bill Gates" },
                new Customer { CustomerId = 2, CustomerName = "Mark Zuckerberg" },
                new Customer { CustomerId = 3, CustomerName = "Elon Musk" }
                );

            mb.Entity<CreditCard>().HasData(
                new CreditCard { CardId = 10, CustomerId = 1, NameOnCard = "Billy Gates III", CardNumber = "4242424242424242", ExpirationDate = "202912", SecurityCode = "123" },
                new CreditCard { CardId = 11, CustomerId = 1, NameOnCard = "Billy Gates II", CardNumber = "1111222233334444", ExpirationDate = "202512", SecurityCode = "333" },
                new CreditCard { CardId = 12, CustomerId = 1, NameOnCard = "Billy Gates I", CardNumber = "4444333322221111", ExpirationDate = "202612", SecurityCode = "444" },
                new CreditCard { CardId = 20, CustomerId = 2, NameOnCard = "Mark Zuck", CardNumber = "7777888899991111", ExpirationDate = "202712", SecurityCode = "555" },
                new CreditCard { CardId = 30, CustomerId = 3, NameOnCard = "EM", CardNumber = "9999888877776666", ExpirationDate = "202812", SecurityCode = "789" }
                );
        }
    }
}
