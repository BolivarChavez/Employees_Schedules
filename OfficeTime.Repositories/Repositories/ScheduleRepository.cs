using OfficeTime.Entities.Interfaces;
using OfficeTime.Entities.Models;
using OfficeTime.Repositories.DataContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficeTime.Repositories.Repositories
{
    //Implemenets the IScheduleRepository interface, isolates the data layer from the Application Business Rules layer
    public class ScheduleRepository : IScheduleRepository
    {
        readonly OfficeTimeContext context = new OfficeTimeContext();

        public List<Schedule> GetSchedule(string filename)
        {
            return context.GetDataFromFile(filename);
        }
    }
}
