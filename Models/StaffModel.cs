using System;
namespace Innovex_Bank.Models
{
	public class StaffModel
	{
		public int Id { get; set; }

		public string Username { get; set; } = string.Empty;

		public string Password { get; set; } = string.Empty;

		public string Fullname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string RoleTitle { get; set; } = "User";

		public bool IsActive { get; set; } = true;
    }
}

