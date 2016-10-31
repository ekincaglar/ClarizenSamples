using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Metadata;

namespace ClarizenSamples.Metadata
{
    class DescribeMetadata_Entity
    {
        static DescribeMetadata_Entity()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            string entityName = "User";  // Could be Customer, Project, User, UserGroup, Task, DiscussionPost, etc.
            describeMetadata metadata = ClarizenAPI.DescribeMetadata(new string[] { entityName }, new string[] { "relations", "fields" });
            if (metadata.IsCalledSuccessfully)
            {
                Console.WriteLine("Fields for the {0} object:", entityName);
                metadata.Data.entityDescriptions[0].SortFields();
                foreach (fieldDescription field in metadata.Data.entityDescriptions[0].fields)
                {
                    Console.WriteLine("\t{0} ({1}) {2}", field.name, field.label, field._type);
                }
            }
            else
                Console.WriteLine(metadata.Error);

            if (ClarizenAPI.Logout())
                Console.WriteLine("{0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }

    }
}
