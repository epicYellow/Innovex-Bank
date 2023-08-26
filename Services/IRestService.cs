using System;
using Innovex_Bank.Models;
namespace Innovex_Bank.Services
{
	public interface IRestService
	{
        // Define all of our REST Methods

        // Get all Staff Members
       Task<List<StaffModel>> RefreshDataAsync();

     

        Task<List<Client>> RefreshClientAsync();

    }
}

