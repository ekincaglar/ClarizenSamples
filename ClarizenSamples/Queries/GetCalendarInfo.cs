using System;
using System.Configuration;
using Clarizen.API.V2_0;
using Clarizen.API.V2_0.Data;

namespace ClarizenSamples.Queries
{
    class GetCalendarInfo
    {
        static GetCalendarInfo()
        {
            API ClarizenAPI = new API();
            if (!ClarizenAPI.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]))
                return;

            string userId = "/User/4dxj4hbs5pqvmp2utn4q3ggib3";
            getCalendarInfo search = ClarizenAPI.GetCalendarInfo(userId);
            if (search.IsCalledSuccessfully)
            {
                Clarizen.API.V2_0.Data.Result.getCalendarInfo result = (Clarizen.API.V2_0.Data.Result.getCalendarInfo)search.Data;
                Console.WriteLine("Week Starts On: {0}", result.weekStartsOn);
                Console.WriteLine("Weekday information:");
                foreach (dayInformation info in result.weekDayInformation)
                {
                    Console.WriteLine("\tisWorkingDay: {0}\ttotalWorkingHours: {1:0.##}\tstartHour: {2:0.##}\tendHour: {3:0.##}",
                        info.isWorkingDay, info.totalWorkingHours, info.startHour, info.endHour);
                }
                Console.WriteLine("Default working day:");
                Console.WriteLine("\tisWorkingDay: {0}\ttotalWorkingHours: {1:0.##}\tstartHour: {2:0.##}\tendHour: {3:0.##}",
                    result.defaultWorkingDay.isWorkingDay, result.defaultWorkingDay.totalWorkingHours, result.defaultWorkingDay.startHour, result.defaultWorkingDay.endHour);
            }
            else
                Console.WriteLine(search.Error);

            if (ClarizenAPI.Logout())
                Console.WriteLine("{0} API calls made in this session", ClarizenAPI.TotalAPICallsMadeInCurrentSession);
        }
    }
}
