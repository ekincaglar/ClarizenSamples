using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Data;
using Clarizen.API.V2_0.Interfaces;

namespace ClarizenSamples.Queries
{
    class CZQL
    {
        static CZQL()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            IClarizenQuery query = new Query()
                      .Select("Name,Work")
                      .From("Task")
                      .Where("StartDate>2016-12-31 AND StartDate<2017-12-31");
            query CZQuery = ClarizenAPI.ExecuteQuery(query);
            if (CZQuery.IsCalledSuccessfully)
            {
                Console.WriteLine("{0} results found", CZQuery.Data.entities.Length);
                foreach (dynamic entity in CZQuery.Data.entities)
                {
                    Console.WriteLine("\t{0}\t{1}", entity.id, entity.Name);
                }
                if (CZQuery.Data.paging.hasMore)
                    Console.WriteLine("There are more records than the ones shown here");
            }
            else
                Console.WriteLine(CZQuery.Error);

            if (ClarizenAPI.Logout())
                Console.WriteLine("{0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }
    }
}
