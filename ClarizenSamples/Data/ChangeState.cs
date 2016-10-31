using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Interfaces;

namespace ClarizenSamples.Data
{
    class ChangeState
    {
        static ChangeState()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            string newState = "Completed";  // Could be Draft, for example

            // First we will get all tasks with due dates earlier than yesterday that are not Completed
            string yesterday = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            IClarizenQuery query = new Query()
                                       .Select("Name,Work,State")
                                       .From("Task")
                                       .Where(String.Format("DueDate<{0} AND State<>\"{1}\"", yesterday, newState));

            Clarizen.API.V2_0.Data.query CZQuery = ClarizenAPI.ExecuteQuery(query);
            if (CZQuery.IsCalledSuccessfully)
            {
                if (CZQuery.Data.entities.Length > 0)
                {
                    // Next, change the state of those tasks to Completed
                    // Note that this does not work for tasks in multiple projects
                    Clarizen.API.V2_0.Data.changeState cs = ClarizenAPI.ChangeState(CZQuery.Data.GetEntityIds(), newState);
                    if (cs.IsCalledSuccessfully)
                    {
                        Console.WriteLine("{0} tasks set to {1}", CZQuery.Data.entities.Length, newState);
                    }
                    else
                        Console.WriteLine(cs.Error);
                }
                else
                    Console.WriteLine("No tasks found with due dates earlier than yesterday");

                if (CZQuery.Data.paging.hasMore)
                    Console.WriteLine("There are more records than the ones processed here");
            }
            else
                Console.WriteLine(CZQuery.Error);

            if (ClarizenAPI.Logout())
                Console.WriteLine("{0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }
    }
}
