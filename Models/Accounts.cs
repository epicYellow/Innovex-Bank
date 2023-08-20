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

        public string Account_number { get; set; } = string.Empty;

        public int Type_id { get; set;} = int.MaxValue;

        public float Transaction_fee { get; set;} = float.MaxValue;

        public float Balance { get; set; } = float.MaxValue;

        public int Client_id { get; set;} =  0;
    }
}
