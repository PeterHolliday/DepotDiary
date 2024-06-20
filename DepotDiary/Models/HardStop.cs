namespace DepotDiary.Models
{
    public class HardStop
    {
        public string Day { get; set; }
        public DateTime StopDate { get; set; }
        public string Times { get; set; }
        public string Depot { get; set; }
        public string StartTime
        {
            get
            {
                return Times.Substring(0, 5).Replace(":", "");
            }
        }
        public string StopTime
        {
            get
            {
                return Times.Substring(8, 5).Replace(":", "");
            }
        }
    }
}
