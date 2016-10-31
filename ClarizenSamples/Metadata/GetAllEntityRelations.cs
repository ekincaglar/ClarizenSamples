using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Metadata;

namespace ClarizenSamples.Metadata
{
    class GetAllEntityRelations
    {
        static GetAllEntityRelations()
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
                describeEntityRelations entities = ClarizenAPI.DescribeEntityRelations(metadata.Data.typeNames);
                if (entities.IsCalledSuccessfully)
                    WriteEntityRelationsDescription(entities.Data.entityRelations);
                else
                    Console.WriteLine(entities.Error);
            }
            else
                Console.WriteLine(metadata.Error);

            if (ClarizenAPI.Logout())
                Console.WriteLine("{0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }

        static void WriteEntityRelationsDescription(entityRelationsDescription[] entityRelations)
        {
            foreach (entityRelationsDescription description in entityRelations)
            {
                description.SortRelations();
                Console.WriteLine("Relationships for the {0} object:", description.typeName);
                foreach (relationDescription relation in description.relations)
                {
                    Console.WriteLine("\t{0} ({1}) {2}-{3} {4}", relation.name, relation.label, relation.sourceFieldName, relation.relatedTypeName, relation.linkTypeName);
                }
                Console.WriteLine("");
            }
        }
    }
}
