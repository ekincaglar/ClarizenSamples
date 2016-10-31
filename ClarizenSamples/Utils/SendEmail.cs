using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Utils;

namespace ClarizenSamples.Utils
{
    class SendEmail
    {
        static SendEmail()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            // Set up the email
            recipient[] recipients = new recipient[] { new recipient(recipient.CZRecipientType.To, "ekin@caglar.com", "/User/4dxj4hbs5pqvmp2utn4q3ggib3") };
            // To sen en email to an external user, initialise recipients without an User EntityId
            //recipient[] recipients = new recipient[] { new recipient(recipient.CZRecipientType.To, "ekin@woto.com", "") };
            string subject = "Hello world";
            string body = "This is an email test from the API";
            string relatedEntityId = String.Empty;
            Clarizen.API.V2_0.Utils.Request.sendEMail.CZAccessType accessType = Clarizen.API.V2_0.Utils.Request.sendEMail.CZAccessType.Public;

            // Send the email
            sendEMail util = ClarizenAPI.SendEmail(recipients, subject, body, relatedEntityId, accessType);
            if (util.IsCalledSuccessfully)
                Console.WriteLine("Email sent successfully");
            else
                Console.WriteLine("Email could not be sent. Error: " + util.Error);

            if (ClarizenAPI.Logout())
                Console.WriteLine("Logout successful. {0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }
    }
}
