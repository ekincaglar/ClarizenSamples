using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Data;

namespace ClarizenSamples.Queries
{
    class GroupsQuery
    {
        static GroupsQuery()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            entityQuery entityQuery = ClarizenAPI.GetAllEntities("User", new string[] { "FirstName", "LastName", "Email", "UserName" });
            if (entityQuery.IsCalledSuccessfully)
            {
                Console.WriteLine("{0} users found", entityQuery.Data.entities.Length);
                foreach (dynamic user in entityQuery.Data.entities)
                {
                    Console.WriteLine("\t{0}\t{1} {2}, {3} (Username: {4})", user.id, user.FirstName, user.LastName, user.Email, user.UserName);
                }
                if (entityQuery.Data.paging.hasMore)
                    Console.WriteLine("There are more records than the ones shown here");
            }
            else
                Console.WriteLine(entityQuery.Error);

            if (ClarizenAPI.Logout())
                Console.WriteLine("{0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }
    }
}
