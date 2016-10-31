using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Data;

namespace ClarizenSamples.Queries
{
    class EntityFeedQuery
    {
        static EntityFeedQuery()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            string taskId = "/Task/4batkam0jt4xn0l3cdx4y8ueg4";
            entityFeedQuery op = ClarizenAPI.EntityFeedQuery(taskId, new string[] { "Body", "Text", "likesCount" });
            if (op.IsCalledSuccessfully)
            {
                int itemCount = op.Data.items.Length;
                Console.WriteLine("This task has {0} items in its social feed:", itemCount);
                if (itemCount > 0)
                {
                    foreach (dynamic discussionPost in op.Data.items)
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2} likes", discussionPost.message.id, discussionPost.message.Body, discussionPost.message.likesCount);
                    }
                }
            }
            else
                Console.WriteLine(op.Error);

            if (ClarizenAPI.Logout())
                Console.WriteLine("{0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }
    }
}
