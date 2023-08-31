using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovex_Bank.Models
{
     public class Accounts
    {
        public int Id { get; set; }

        public string Account_number { get; set; }

        public int Type_id { get; set;}

        public float Transaction_fee { get; set;}

        public float Balance { get; set; }

        public int Client_id { get; set;}
    }
}
