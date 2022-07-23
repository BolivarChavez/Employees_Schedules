using OfficeTime.Entities.Models;
using OfficeTime.Services.Interfaces;
using System.Collections.Generic;

namespace OfficeTime.Con
{
    //Class used to inject dependency to the IEmployeePair interface
    public class Application
    {
        private readonly IEmployeePair _employeePair;

        public Application(IEmployeePair employeePair)
        {
            _employeePair = employeePair;
        }

        public List<EmployeePair> GetPairs(string filename)
        {
            return  _employeePair.GetEmployeePairs(filename);
        }
    }
}
