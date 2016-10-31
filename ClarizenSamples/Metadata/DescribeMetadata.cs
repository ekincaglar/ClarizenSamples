using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Metadata;
using ObjectDumper;

namespace ClarizenSamples.Metadata
{
    class DescribeMetadata
    {
        static DescribeMetadata()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            describeMetadata describeMetadata = ClarizenAPI.DescribeMetadata();
            if (describeMetadata.IsCalledSuccessfully)
                Console.WriteLine(describeMetadata.Data.DumpToString("describeMetadata"));
            else
                Console.WriteLine(describeMetadata.Error);

            if (ClarizenAPI.Logout())
                Console.WriteLine("{0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }
    }
}
