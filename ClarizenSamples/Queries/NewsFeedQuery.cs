using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Data;

namespace ClarizenSamples.Queries
{
    class NewsFeedQuery
    {
        static NewsFeedQuery()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            newsFeedQuery op = ClarizenAPI.NewsFeedQuery(newsFeedMode.All, new string[] { "Body", "Text", "likesCount" });
            if (op.IsCalledSuccessfully)
            {
                Console.WriteLine("Current user has {0} items in his/her news feed", op.Data.items.Length);
                foreach (postFeedItem item in op.Data.items)
                {
                    //Console.WriteLine(item.message);
                    Console.WriteLine("\t{0}\t{1}\t{2} likes", item.message.id, item.message.Body, item.message.likesCount);
                }
            }
            else
                Console.WriteLine(op.Error);

            if (ClarizenAPI.Logout())
                Console.WriteLine("{0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }
    }
}
