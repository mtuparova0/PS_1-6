using System;
using System.Collections.Generic;

using System.IO;
using System.Text;
using System.Linq;

namespace UserLogin
{
    static public class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();

        private const string LogFileName = "log.txt";


        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + " "
                 + LoginValidation.User.Username + " " + LoginValidation.User.Role + " " + activity;
            currentSessionActivities.Add(activityLine);

            StreamWriter streamWriter = new StreamWriter(LogFileName);
            streamWriter.WriteLine(activityLine);
            streamWriter.Close();
        }

        public static void ReadFullLog()
        {
            StreamReader stream = new StreamReader(LogFileName);
            StringBuilder sb = new StringBuilder();

            while (true)
            {
                var line = stream.ReadLine();

                if (line != null)
                {
                    sb.Append(line);
                }
                else
                    break;

                Console.Write(sb);
            }

            stream.Close();
        }

        public static IEnumerable<string> getCurrentSessionActivities(string filter)
        {
            List<string> filteredActivites = (from activity in currentSessionActivities where activity.Contains(filter) select activity).ToList();


            return filteredActivites;
        }
    }
}
