using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Innovex_Bank.Models
{
	public class Staff
	{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public float Income { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string RoleTitle { get; set; } = "Staff";
    }
}

