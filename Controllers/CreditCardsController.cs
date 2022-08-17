using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CreditCardWebApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CreditCardWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private readonly ShopContext _context;

        public CreditCardsController(ShopContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();

        }

        // GET: api/CreditCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreditCard>>> GetCreditCards()
        {
            return await _context.CreditCards.ToListAsync();
        }

        // GET: api/CreditCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CreditCard>> GetCreditCard(int id)
        {
            var creditCard = await _context.CreditCards.FindAsync(id);

            if (creditCard == null)
            {
                return NotFound();
            }

            return creditCard;
        }


        [HttpPost]
        public async Task<ActionResult<CreditCard>> ReceiveCustomer(RequestDTO dto)
        {
            CreditCard creditCard = new CreditCard()
            {
                CustomerId = dto.CustomerId,
                CardNumber = dto.CardNumber,
                CVV = dto.CVV,
                Token = GenerateToken(dto)
            };
            _context.CreditCards.Add(creditCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCreditCard", new { id = creditCard.CardId }, creditCard);
        }


        [HttpPost]
        public async Task<ActionResult<bool>> ValidateToken(Request2DTO dto)
        {
            var creditCard = await _context.CreditCards.FindAsync(dto.CardId);

            if (creditCard == null)
            {
                return false;
            }

            if (creditCard.Token != dto.Token ||
                creditCard.CardId != dto.CardId ||
                creditCard.CVV != dto.CVV)
            {
                return false;
            }

            return true;
        }

        // PUT: api/CreditCards/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCreditCard(int id, CreditCard creditCard)
        //{
        //    if (id != creditCard.CardId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(creditCard).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CreditCardExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // DELETE: api/CreditCards/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCreditCard(int id)
        //{
        //    var creditCard = await _context.CreditCards.FindAsync(id);
        //    if (creditCard == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.CreditCards.Remove(creditCard);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CreditCardExists(int id)
        //{
        //    return _context.CreditCards.Any(e => e.CardId == id);
        //}

        private string GenerateToken(RequestDTO dto)
        {
            var last4Digits = dto.CardNumber.Substring(dto.CardNumber.Length - 4, 4);
            var _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("CreditCard" + last4Digits + dto.CVV));
            var _issuer = "https://localhost:5001";
            var _audience = "https://localhost:5001";

            var signinCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signinCredentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            //return $"Token = {tokenString}";
            return $"{tokenString}";
        }
    }
}
