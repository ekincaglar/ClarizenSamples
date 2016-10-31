using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Data;

namespace ClarizenSamples.Data
{
    class GetTemplateDescriptions
    {
        static GetTemplateDescriptions()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            string typeName = "Project";
            getTemplateDescriptions search = ClarizenAPI.GetTemplateDescriptions(typeName);
            if (search.IsCalledSuccessfully)
            {
                Console.WriteLine("{0} templates found for {1}", search.Data.templates.Length, typeName);
                if (search.Data.templates.Length > 0)
                {
                    foreach (string template in search.Data.templates)
                    {
                        Console.WriteLine("\t{0}", template);
                    }
                }
            }
            else
                Console.WriteLine(search.Error);

            if (ClarizenAPI.Logout())
                Console.WriteLine("{0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }
    }
}
