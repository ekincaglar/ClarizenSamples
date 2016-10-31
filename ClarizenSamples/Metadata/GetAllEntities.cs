using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Metadata;

namespace ClarizenSamples.Metadata
{
    class GetAllEntities
    {
        static GetAllEntities()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            listEntities metadata = ClarizenAPI.ListEntities();
            if (metadata.IsCalledSuccessfully)
            {
                metadata.Data.SortTypeNames();
                Console.WriteLine("{0} entities found", metadata.Data.typeNames.Length);
                // Note that the following query will be truncated at 2000 characters (RestClient.GET limitation)
                describeEntities entities = ClarizenAPI.DescribeEntities(metadata.Data.typeNames);
                if (entities.IsCalledSuccessfully)
                {
                    foreach (entityDescription description in entities.Data.entityDescriptions)
                    {
                        description.SortFields();
                        Console.WriteLine("Fields for the {0} object:", description.typeName);
                        foreach (fieldDescription field in description.fields)
                        {
                            Console.WriteLine("\t{0} ({1}) {2}", field.name, field.label, field._type);
                        }
                        Console.WriteLine("");
                    }
                }
                else
                    Console.WriteLine(entities.Error);
            }
            else
                Console.WriteLine(metadata.Error);

            if (ClarizenAPI.Logout())
                Console.WriteLine("{0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }
    }
}
