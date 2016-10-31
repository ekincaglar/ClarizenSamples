using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Data;
using Clarizen.POCO;

namespace ClarizenSamples.Data
{
    class CreateFromTemplate
    {
        static CreateFromTemplate()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            Project project = new Project("/Project", "Ekin's test project");
            string templateName = "Your First Project";
            string parentId = String.Empty;

            createFromTemplate op = ClarizenAPI.CreateFromTemplate(project, templateName, parentId);
            if (op.IsCalledSuccessfully)
                Console.WriteLine("New entity created. Id: {0}", op.Data.id);
            else
                Console.WriteLine(op.Error);

            if (ClarizenAPI.Logout())
                Console.WriteLine("{0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }
    }
}
