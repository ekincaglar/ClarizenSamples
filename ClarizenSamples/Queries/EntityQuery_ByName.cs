using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Data;

namespace ClarizenSamples.Queries
{
    class EntityQuery_ByName
    {
        static EntityQuery_ByName()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            string entityName = "Task";  // Could be any entity that has the Name field, e.g. Project
            entityQuery entityQuery = ClarizenAPI.GetAllEntities(entityName, new string[] { "Name" });
            if (entityQuery.IsCalledSuccessfully)
            {
                Console.WriteLine("{0} {1} entities found", entityQuery.Data.entities.Length, entityName);
                foreach (dynamic entity in entityQuery.Data.entities)
                {
                    Console.WriteLine("\t{0}\t{1}", entity.id, entity.Name);
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
