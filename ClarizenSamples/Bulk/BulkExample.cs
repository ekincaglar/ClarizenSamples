using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Bulk;

namespace ClarizenSamples.Bulk
{
    class BulkExample
    {
        static BulkExample()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            ClarizenAPI.StartBulkService();
            ClarizenAPI.DescribeMetadata(new string[] { "User" }, new string[] { "relations", "fields" });
            ClarizenAPI.DescribeEntityRelations(new string[] { "User" });
            execute bulkService = ClarizenAPI.CommitBulkService();

            if (bulkService.IsCalledSuccessfully)
            {
                foreach (response res in bulkService.Data.responses)
                {
                    if (res.statusCode == 200)
                    {
                        //
                        // Result is cast to its target type so it could be used as follows
                        //
                        switch (res.BodyType)
                        {
                            case "Clarizen.API.V2_0.Metadata.Result.describeMetadata":
                                WriteEntityFields(res.body.entityDescriptions[0]);
                                break;
                            case "Clarizen.API.V2_0.Metadata.Result.describeEntityRelations":
                                WriteEntityRelationsDescription(res.body.entityRelations);
                                break;
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Error {0}: {1}", res.statusCode, ((error)res.body).formatted);
                    }
                }
            }
            else
                Console.WriteLine("Bulk service failed. Error: " + bulkService.Error);

            if (ClarizenAPI.Logout())
                Console.WriteLine("{0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }

        static void WriteEntityFields(entityDescription entity)
        {
            Console.WriteLine("Fields for the {0} entity", entity.typeName);
            entity.SortFields();
            foreach (fieldDescription field in entity.fields)
            {
                Console.WriteLine("\t{0} ({1}) {2}", field.name, field.label, field._type);
            }
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
