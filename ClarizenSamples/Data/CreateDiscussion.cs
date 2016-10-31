using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.POCO;

namespace ClarizenSamples.Data
{
    class CreateDiscussion
    {
        static CreateDiscussion()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            string parentTaskId = "/Task/4batkam0jt4xn0l3cdx4y8ueg4";
            DiscussionPost discussionPost = new DiscussionPost("/DiscussionPost", "This discussion is created by API", parentTaskId, "Integration Tool");
            Clarizen.API.V2_0.Data.createDiscussion op = ClarizenAPI.CreateDiscussion(discussionPost);
            if (op.IsCalledSuccessfully)
                Console.WriteLine("Discussion created successfully");
            else
                Console.WriteLine(op.Error);

            if (ClarizenAPI.Logout())
                Console.WriteLine("{0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }
    }
}
