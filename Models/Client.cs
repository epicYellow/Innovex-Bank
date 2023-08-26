using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovex_Bank.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Id_number { get; set; }
        public string Date_of_birth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone_number { get; set; }
        public bool Employment_status { get; set;}
        public float Monthly_income { get; set;}
    }
}
