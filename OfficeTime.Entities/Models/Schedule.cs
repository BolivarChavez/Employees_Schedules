namespace OfficeTime.Entities.Models
{
    public class Schedule
    {
        //Employee name
        public string employee_name { get; set; }
        //Week day
        public string week_day { get; set; }
        //Check in time
        public string time_in { get; set; }
        //Check out time
        public string time_out { get; set; }
        //True if the data is correct, False if it is an error in the data
        public bool validate { get; set; }
    }
}
