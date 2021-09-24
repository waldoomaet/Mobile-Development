using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class User
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string IdentificationDocument { get; set; }
        public string Email { get; set; }
        public Int64? CreditCardNumber { get; set; }
        public int? CVV { get; set; }
        public DateTime? CreditCardExpirationDate { get; set; }
        public string Password { get; set; }
    }
}
