using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Data;

namespace ClarizenSamples.Queries
{
    class RepliesQuery
    {
        static RepliesQuery()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            string discussionPostId = "/DiscussionPost/msg-4npjkyrj89buagdjkxtr4ja1o";
            repliesQuery op = ClarizenAPI.RepliesQuery(discussionPostId, new string[] { "Body", "Text", "likesCount" });
            if (op.IsCalledSuccessfully)
            {
                int itemCount = op.Data.items.Length;
                Console.WriteLine("This DiscussionPost has {0} replies{1}", itemCount, itemCount > 0 ? ":" : "");
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
