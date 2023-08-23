using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Innovex_Bank.Services
{
    public class AuthService
    {

        private const string AuthStateKey = "AuthState";

        // Constructor
        public AuthService()
        { 
        }

        // Check Authentication
        public async Task<bool> IsAuthenticatedAsync()
        {


            // Getting local storage state of the auth
            var authState = Preferences.Default.Get<bool>(AuthStateKey, false);

            return authState;
        }

        // Set Authenticated User

        // Remove Authenticated user

    }
}
