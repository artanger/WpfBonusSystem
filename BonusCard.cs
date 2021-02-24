using System;
using System.Collections.Generic;
using System.Text;

namespace ClientBonusSystem.Models
{
    public class BonusCard
    {

        public string PhoneNumber { get; set; }

        public string FirstName{ get; set; }

        public string LastName { get; set; }

        public string CardNumber { get; set; }

        //public string CreationDate { get; set; }
         public DateTime? CreationDate { get; set; }

        //public string ExpirationDate { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public int? Balance { get; set; }
    }
}
