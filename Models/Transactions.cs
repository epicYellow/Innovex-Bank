using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovex_Bank.Models
{
    public class Transactions
    {
        public int Id { get; set; }
        public string Transaction_type { get; set; }
        public float Amount { get; set;}
        public string Date_and_time { get; set;}
        public float Transaction_fee { get; set;}
        public int Account_Id { get; set; }
    }
}
