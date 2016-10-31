using System;
using System.Configuration;
using Clarizen.API.V2_0;

namespace ClarizenSamples.Authentication
{
    class Login
    {
        static Login()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            Console.WriteLine("Login successful");
            Console.WriteLine("Server location: {0}", ClarizenAPI.serverLocation);
            Console.WriteLine("Session Id: {0}", ClarizenAPI.sessionId);

            // Your API code goes here...

            if (ClarizenAPI.Logout())
                Console.WriteLine("Logout successful. {0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }
    }
}
