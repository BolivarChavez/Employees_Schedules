using OfficeTime.Test.Models;
using OfficeTime.Test.Services;
using System.Collections.Generic;
using Xunit;

namespace OfficeTime.UnitTest
{
    public class TestValidatePairs
    {
        [Fact]
        public void NotValidResult ()
        {
            List<Schedule> schedule_list = new List<Schedule>();
            List<EmployeePair> pair_list = new List<EmployeePair>();
            ValidatePairs test_validate_pairs = new ValidatePairs();

            schedule_list.Add(new Schedule { employee_name = "RENE", week_day = "MO", time_in = "10:15", time_out = "12:00", validate = true });
            schedule_list.Add(new Schedule { employee_name = "RENE", week_day = "TU", time_in = "10:00", time_out = "12:00", validate = true });
            schedule_list.Add(new Schedule { employee_name = "RENE", week_day = "TH", time_in = "13:00", time_out = "13:15", validate = true });
            schedule_list.Add(new Schedule { employee_name = "RENE", week_day = "SA", time_in = "14:00", time_out = "18:00", validate = true });
            schedule_list.Add(new Schedule { employee_name = "RENE", week_day = "SU", time_in = "20:00", time_out = "21:00", validate = true });
            schedule_list.Add(new Schedule { employee_name = "ASTRID", week_day = "MO", time_in = "10:00", time_out = "12:00", validate = true });
            schedule_list.Add(new Schedule { employee_name = "ASTRID", week_day = "TU", time_in = "12:00", time_out = "14:00", validate = true });
            schedule_list.Add(new Schedule { employee_name = "ASTRID", week_day = "SU", time_in = "20:00", time_out = "21:00", validate = true });

            pair_list.Add(new EmployeePair { employee_names = "ASTRID-RENE", pair_count = 1 });

            bool isValid = test_validate_pairs.IsValid(schedule_list, pair_list);

            Assert.False(isValid, $"The number of pairs correct");
        }

        [Fact]
        public void ValidResult()
        {
            List<Schedule> schedule_list = new List<Schedule>();
            List<EmployeePair> pair_list = new List<EmployeePair>();
            ValidatePairs test_validate_pairs = new ValidatePairs();

            schedule_list.Add(new Schedule { employee_name = "RENE", week_day = "MO", time_in = "10:15", time_out = "12:00", validate = true });
            schedule_list.Add(new Schedule { employee_name = "RENE", week_day = "TU", time_in = "10:00", time_out = "12:00", validate = true });
            schedule_list.Add(new Schedule { employee_name = "RENE", week_day = "TH", time_in = "13:00", time_out = "13:15", validate = true });
            schedule_list.Add(new Schedule { employee_name = "RENE", week_day = "SA", time_in = "14:00", time_out = "18:00", validate = true });
            schedule_list.Add(new Schedule { employee_name = "RENE", week_day = "SU", time_in = "20:00", time_out = "21:00", validate = true });
            schedule_list.Add(new Schedule { employee_name = "ASTRID", week_day = "MO", time_in = "10:00", time_out = "12:00", validate = true });
            schedule_list.Add(new Schedule { employee_name = "ASTRID", week_day = "TU", time_in = "12:00", time_out = "14:00", validate = true });
            schedule_list.Add(new Schedule { employee_name = "ASTRID", week_day = "SU", time_in = "20:00", time_out = "21:00", validate = true });

            pair_list.Add(new EmployeePair { employee_names = "ASTRID-RENE", pair_count = 3 });

            bool isValid = test_validate_pairs.IsValid(schedule_list, pair_list);

            Assert.False(isValid, $"The number of pairs is not correct");
        }
    }
}
