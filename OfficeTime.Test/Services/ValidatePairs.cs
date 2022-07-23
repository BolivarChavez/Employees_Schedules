using OfficeTime.Test.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace OfficeTime.Test.Services
{
    public class ValidatePairs
    {
        public bool IsValid(List<Schedule> listschedules, List<EmployeePair> listpairs)
        {
            string[] week_days = { "SU", "MO", "TU", "WE", "TH", "FR", "SA" };
            DateTime emp_time_in, emp_time_out;
            string emp_name;
            List<EmployeePair> list_employee = new List<EmployeePair>();
            List<Schedule> list_schedule = new List<Schedule>();

            for (int i = 0; i <= 6; i++)
            {
                var schedules = listschedules.Where(p => p.week_day == week_days[i]).OrderBy(p => p.employee_name).ToList();

                if (schedules.Count() > 0)
                {
                    for (int j = 0; j < schedules.Count() - 1; j++)
                    {
                        emp_name = schedules[j].employee_name.Trim();
                        emp_time_in = DateTime.ParseExact(schedules[j].time_in.Trim(), "HH:mm", CultureInfo.InvariantCulture);
                        emp_time_out = DateTime.ParseExact(schedules[j].time_out.Trim(), "HH:mm", CultureInfo.InvariantCulture);

                        list_schedule.Clear();
                        list_schedule = schedules.GetRange(j + 1, schedules.Count() - j - 1);

                        var employees = list_schedule.Where(p =>
                        (emp_time_in >= DateTime.ParseExact(p.time_in.Trim(), "HH:mm", CultureInfo.InvariantCulture) && emp_time_in <= DateTime.ParseExact(p.time_out.Trim(), "HH:mm", CultureInfo.InvariantCulture)) ||
                        (emp_time_out >= DateTime.ParseExact(p.time_in.Trim(), "HH:mm", CultureInfo.InvariantCulture) && emp_time_out <= DateTime.ParseExact(p.time_out.Trim(), "HH:mm", CultureInfo.InvariantCulture)) ||
                        (DateTime.ParseExact(p.time_in.Trim(), "HH:mm", CultureInfo.InvariantCulture) >= emp_time_in && DateTime.ParseExact(p.time_in.Trim(), "HH:mm", CultureInfo.InvariantCulture) <= emp_time_out) ||
                        (DateTime.ParseExact(p.time_out.Trim(), "HH:mm", CultureInfo.InvariantCulture) >= emp_time_in && DateTime.ParseExact(p.time_out.Trim(), "HH:mm", CultureInfo.InvariantCulture) <= emp_time_out)
                        ).ToList();

                        for (int k = 0; k < employees.Count(); k++)
                        {
                            list_employee.Add(new EmployeePair { employee_names = emp_name + "-" + employees[k].employee_name, pair_count = 1 });
                        }
                    }
                }
            }

            var employee_pairs = list_employee.GroupBy(n => n.employee_names)
                                     .Select(n => new EmployeePair
                                     {
                                         employee_names = n.Key,
                                         pair_count = n.Count()
                                     })
                                     .OrderBy(n => n.employee_names);

            if (employee_pairs.Count() != listpairs.Count())
                return false;
            else
                return Enumerable.SequenceEqual(employee_pairs, listpairs);
        }
    }
}
