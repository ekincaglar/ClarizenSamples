using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Data.Queries;

namespace ClarizenSamples.Queries
{
    class AggregateQuery
    {
        static AggregateQuery()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            // This is the example on https://api.clarizen.com/V2.0/services/data/AggregateQuery
            aggregateQuery query = 
                new aggregateQuery("Task",
                                   new fieldAggregation[] { new fieldAggregation("Count", "Name", "Cnt") },
                                   new string[] { "State" },
                                   new orderBy[] { new orderBy("Cnt", "Descending") });
            Clarizen.API.V2_0.Data.aggregateQuery aggregateQuery = ClarizenAPI.AggregateQuery(query);
            if (aggregateQuery.IsCalledSuccessfully)
            {
                Console.WriteLine("{0} entities found", aggregateQuery.Data.entities.Length);
                foreach (dynamic entity in aggregateQuery.Data.entities)
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}", entity.id, entity.State.id, entity.Cnt);
                }
                if (aggregateQuery.Data.paging.hasMore)
                    Console.WriteLine("There are more records than the ones shown here");
            }
            else
                Console.WriteLine(aggregateQuery.Error);

            if (ClarizenAPI.Logout())
                Console.WriteLine("{0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }
    }
}
