using OfficeTime.Entities.Models;
using System.Collections.Generic;

namespace OfficeTime.Services.Interfaces
{
    //Interface defined to inject dependency of the use case interactor to the console app.
    public interface IEmployeePair
    {
        public List<EmployeePair> GetEmployeePairs(string filename);
    }
}
