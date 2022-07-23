using OfficeTime.Entities.Interfaces;
using OfficeTime.Entities.Models;
using OfficeTime.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;

namespace OfficeTime.Services.Services
{
    //Implements the use case
    public class EmployeePairInteractor : IEmployeePair
    {
        readonly IScheduleRepository Repository;

        public EmployeePairInteractor(IScheduleRepository repository)
        {
            Repository = repository;
        }

        public List<EmployeePair> GetEmployeePairs(string filename)
        {
            string[] week_days = { "SU", "MO", "TU", "WE", "TH", "FR", "SA" };
            DateTime emp_time_in, emp_time_out;
            string emp_name;
            List<EmployeePair> list_employee = new List<EmployeePair>();
            List<Schedule> list_schedule = new List<Schedule>();

            //Read file and get a list of Schedule class objects
            var file_input = Repository.GetSchedule(filename);

            //If there are schedules with errors the error will be returned
            if (file_input.Where(p => p.validate == false).Count() > 0)
            {
                var error_pair = file_input.Where(p => p.validate == false).Select(p => new EmployeePair { employee_names = p.employee_name, pair_count = 0});
                return error_pair.ToList();
            }

            //If there are no errors then the use case is evaluated
            for (int i = 0; i <= 6; i++)
            {
                //Get schedules for each individual day begining with sunday and ending with saturday, and the records are ordered by name
                var schedules = file_input.Where(p => p.week_day == week_days[i]).OrderBy(p => p.employee_name).ToList();

                if (schedules.Count() > 0)
                {
                    //For each employee the algorithm compare his or her check in and check out times with those belonging to the other employees
                    for (int j = 0; j < schedules.Count() - 1; j++)
                    {
                        emp_name = schedules[j].employee_name.Trim();
                        emp_time_in = DateTime.ParseExact(schedules[j].time_in.Trim(), "HH:mm", CultureInfo.InvariantCulture);
                        emp_time_out = DateTime.ParseExact(schedules[j].time_out.Trim(), "HH:mm", CultureInfo.InvariantCulture);

                        list_schedule.Clear();
                        list_schedule = schedules.GetRange(j + 1, schedules.Count() - j - 1);

                        //If the check in time of the current employee is between the check in and check out times of others it is added.
                        //If the check out time of the current employee is between the check in and check out times of others it is added.
                        //If the check in time of the other employee is between the check in and check out times of the current employee, it is added.
                        //If the check out time of the other employee is between the check in and check out times of the current employee, it is added.
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

            //Grouping by name to get the total count
            var employee_pairs = list_employee.GroupBy(n => n.employee_names)
                                     .Select(n => new EmployeePair
                                     {
                                         employee_names = n.Key,
                                         pair_count = n.Count()
                                     })
                                     .OrderBy(n => n.employee_names);

            return employee_pairs.ToList();
        }
    }
}
