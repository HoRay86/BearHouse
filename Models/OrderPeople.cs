using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class OrderPeople
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
        public string Requests { get; set; }
        [StringLength(16)]
        public string CardNumber { get; set; }

        public string CreditName { get; set; }

        public string Cvv { get; set; }

        public int PurchaseAmount { get; set; }
        public string Expirydate { get; set; }
    }
}
