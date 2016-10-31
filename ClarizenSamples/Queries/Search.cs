using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Data;

namespace ClarizenSamples.Queries
{
    class Search
    {
        static Search()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            string q = "ekin";
            search search = ClarizenAPI.Search(q);
            if (search.IsCalledSuccessfully)
                Console.WriteLine("{0} entities found with {1}", search.Data.entities.Length, q);
            else
                Console.WriteLine(search.Error);

            if (ClarizenAPI.Logout())
                Console.WriteLine("{0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }
    }
}
