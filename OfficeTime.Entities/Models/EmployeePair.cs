namespace OfficeTime.Entities.Models
{
    public class EmployeePair
    {
        //Names of employees that have been at the office at the same day and time lapse.
        public string employee_names { get; set; }
        //Count how many times the employees have been at the office
        public int pair_count { get; set; }
    }
}
