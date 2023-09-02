using Innovex_Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovex_Bank.Services
{
    internal interface IRestClientService
    {
        Task<List<Client>> RefreshClientAsync();
    }
}
