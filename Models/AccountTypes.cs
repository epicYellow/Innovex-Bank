using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovex_Bank.Models
{
    public class AccountTypes
    {
        public int Id { get; set; }

        public string Type_name { get; set; } = string.Empty;

        public float Transaction_fee { get; set; } = float.MaxValue;

        public float Annual_interest_rate { get; set; } = float.MaxValue;

        public int Free_limit { get; set; } = 0;
    }
}
