using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Data;
using Clarizen.POCO;

namespace ClarizenSamples.Data
{
    class CreateAndRetrieve
    {
        static CreateAndRetrieve()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            Task task = new Task("/Task", "Here is a new task");

            createAndRetrieve op = ClarizenAPI.CreateAndRetrieve(task, new string[] { "Name" });
            if (op.IsCalledSuccessfully)
            {
                Console.WriteLine("\t{0}\t{1}", op.Data.entity.id, op.Data.entity.Name);
            }
            else
                Console.WriteLine(op.Error);

            if (ClarizenAPI.Logout())
                Console.WriteLine("{0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }
    }
}
