using OfficeTime.Entities.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OfficeTime.Repositories.DataContext
{
    public class OfficeTimeContext
    {
        //Read each line from the text file and return the list of Schedule class objects
        public List<Schedule> GetDataFromFile(string filename)
        {
            string[] names;
            string[] schedules;
            string[] times;
            string employee_name;
            string week_day;
            int linenumber;
            string[] week_days = { "SU", "MO", "TU", "WE", "TH", "FR", "SA" };
            List<string> tmp_schedule = new List<string>();
            //Regex used to validate file format
            Regex checkline = new Regex(@"^[A-Z]+=((((?:SU|MO|TU|WE|TH|FR|SA?)(?:[01]?[0-9]|2[0-3]):[0-5][0-9])-((?:[01]?[0-9]|2[0-3]):[0-5][0-9]))+,)*(((?:SU|MO|TU|WE|TH|FR|SA?)(?:[01]?[0-9]|2[0-3]):[0-5][0-9])-((?:[01]?[0-9]|2[0-3]):[0-5][0-9]))+$");
            List<Schedule> schedule_list = new List<Schedule>();

            linenumber = 0;
            foreach (string line in System.IO.File.ReadLines(@filename))
            {
                linenumber++;

                if (line.Trim() == "")
                {
                    schedule_list.Add(new Schedule { employee_name = "ERROR: Line is empty. Line: " + linenumber.ToString().Trim(), week_day = "XX", time_in = "00:00", time_out = "00:00", validate = false });
                    continue;
                }

                if (!checkline.IsMatch(line))
                {
                    schedule_list.Add(new Schedule { employee_name = "ERROR: The line must be typed in the appropiate format. Line: " + linenumber.ToString().Trim(), week_day = "XX", time_in = "00:00", time_out = "00:00", validate = false });
                    continue;
                }

                //Split name and check in and check out times
                names = line.Split('=');

                if (names[1].IndexOf(",") <= 0)
                {
                    tmp_schedule.Clear();
                    tmp_schedule.Add(names[1].Trim());
                    schedules = tmp_schedule.ToArray();
                    employee_name = names[0].Trim();
                }
                else
                {
                    schedules = names[1].Split(',');
                    employee_name = names[0].Trim();
                }

                //Split check in and check out times from each day and stored in a Schedule class object
                for (int i = 0; i < schedules.Length; i++)
                {
                    week_day = schedules[i].Substring(0, 2);
                    times = schedules[i].Substring(2).Split('-');
                    schedule_list.Add(new Schedule { employee_name = employee_name, week_day = week_day, time_in = times[0].Trim(), time_out = times[1].Trim(), validate = true });
                }
            }

            return schedule_list;
        }
    }
}
