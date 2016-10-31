using System;

namespace ClarizenSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Before you start, edit the App.config file and put your Clarizen username and password in appSettings
            // You can then uncomment a line below to test that function
            // Note that you will need to change certain parameters for the functions to work


            // Authentication examples
            // Provides the basic calls to authenticate with the REST API, get session information and 
            // access the correct data center where your organization is located
            //
            new Authentication.Login();
            //new Authentication.GetSessionInfo();

            // CRUD & Data examples
            // Provides the calls to create, update, retrieve and delete objects in Clarizen
            //
            //new Data.CRUD();                      // Create, retrieve, update and delete tasks
            //new Data.CreateAndRetrieve();         // Create and retrieve task
            //new Data.GetTemplateDescriptions();   // Finds the "Your First Project" template for Project
            //new Data.CreateFromTemplate();        // Creates a Project using "Your First Project" template
            //new Data.ChangeState();
            //new Data.CreateDiscussion();

            // Queries
            // Provides the calls to query and search for objects in Clarizen
            //
            //new Queries.CZQL();
            //new Queries.Count();
            //new Queries.EntityQuery_Users();      // Get all users
            //new Queries.EntityQuery_ByName();     // Get all tasks
            //new Queries.AggregateQuery();
            //new Queries.GroupsQuery();
            //new Queries.NewsFeedQuery();
            //new Queries.EntityFeedQuery();
            //new Queries.RepliesQuery();
            //new Queries.GetCalendarInfo();
            //new Queries.Search();

            // Bulk 
            // Allows executing several API calls in a single round trip to the server
            //
            //new Bulk.BulkExample();

            // Utils
            // Send an email and attach it to an object in Clarizen
            //
            //new Utils.SendEmail();

            // Metadata examples
            // Provides information about the Clarizen data model including supported entities,
            // entity fields and data types, and relations between entities
            //
            //new Metadata.DescribeMetadata_Entity();
            //new Metadata.DescribeMetadata();
            //new Metadata.GetAllEntities();
            //new Metadata.GetAllEntityRelations();

            Console.Read();
        }

    }
}
