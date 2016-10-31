using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Data;
using Clarizen.POCO;

namespace ClarizenSamples.Data
{
    class CRUD
    {
        static CRUD()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            // Create a new task
            Task task = new Task("Here is a new task");
            string newTaskId = String.Empty;
            objects_put putObject = ClarizenAPI.CreateObject("/Task", task);
            if (putObject.IsCalledSuccessfully)
            {
                newTaskId = putObject.Data.id;
                Console.WriteLine("New task id: {0}", newTaskId);
            }
            else
                Console.WriteLine(putObject.Error);
            
            if (!String.IsNullOrEmpty(newTaskId))
            {
                // Get task
                objects_get objects = ClarizenAPI.GetObject(newTaskId, new string[] { "Name" });
                if (objects.IsCalledSuccessfully)
                    Console.WriteLine("Task Id: {0}", objects.Data.id);
                else
                    Console.WriteLine(objects.Error);

                // Update task
                Task updateTask = new Task();
                updateTask.Name = "Here is the updated task name";
                objects_post postObject = ClarizenAPI.UpdateObject(newTaskId, updateTask);
                if (postObject.IsCalledSuccessfully)
                    Console.WriteLine("Task updated successfully");
                else
                    Console.WriteLine(postObject.Error);

                // Delete task
                objects_delete deleteObject = ClarizenAPI.DeleteObject(newTaskId);
                if (deleteObject.IsCalledSuccessfully)
                    Console.WriteLine("Task deleted successfully");
                else
                    Console.WriteLine(deleteObject.Error);
            }

            if (ClarizenAPI.Logout())
                Console.WriteLine("{0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }

    }
}
