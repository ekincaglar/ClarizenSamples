using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Authentication;
using ObjectDumper;

namespace ClarizenSamples.Authentication
{
    class GetSessionInfo
    {
        static GetSessionInfo()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            getSessionInfo sessionInfo = ClarizenAPI.GetSessionInfo();
            if (sessionInfo.IsCalledSuccessfully)
                Console.WriteLine(sessionInfo.Data.DumpToString("getSessionInfo"));
            else
                Console.WriteLine(sessionInfo.Error);

            if (ClarizenAPI.Logout())
                Console.WriteLine("{0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }
    }
}
