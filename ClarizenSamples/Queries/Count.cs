using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Data.Queries;
using Clarizen.API.V2_0.Data.Queries.Conditions;
using Clarizen.API.V2_0.Data.Queries.Expressions;

namespace ClarizenSamples.Queries
{
    class Count
    {
        static Count()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            // We will search this term in the DisplayName field of User entities
            string searchTerm = "ekin";

            // Create the search query
            entityQuery query = new entityQuery("User");
            query.where = new compare(new fieldExpression("DisplayName"), Operator.Like, new constantExpression(String.Format("%{0}%", searchTerm)));
            // Here is how to perform the same search using CZQL instead
            //query.where = new cZQLCondition(@"DisplayName LIKE ""%ekin%""");

            // Run the Count method with the query created above
            Clarizen.API.V2_0.Data.countQuery count = ClarizenAPI.Count(query);
            if (count.IsCalledSuccessfully)
                Console.WriteLine("{0} user(s) found with the display name {1}", count.Data.count, searchTerm);
            else
                Console.WriteLine(count.Error);

            if (ClarizenAPI.Logout())
                Console.WriteLine("{0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }
    }
}
