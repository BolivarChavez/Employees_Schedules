using OfficeTime.Entities.Models;
using System.Collections.Generic;

namespace OfficeTime.Entities.Interfaces
{
    public interface IScheduleRepository
    {
        //Interface to be implemented in the repository layer. The expected result is the list of schedules for each of the employees
        //organized as is defined in the Schedule class
        List<Schedule> GetSchedule(string filename);
    }
}
