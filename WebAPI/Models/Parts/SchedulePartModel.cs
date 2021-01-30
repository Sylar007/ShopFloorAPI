using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Parts
{
    public class SchedulePartModel
    {
        public int id { get; set; }
        public string scheduleType { get; set; }
        public string shiftType { get; set; }
        public string workstationName { get; set; }
        public List<Parts> parts { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int requiredQuantity { get; set; }
    }
    public class Parts
    {
        public int id { get; set; }
        public string name { get; set; }
        public string file_url { get; set; }
    }
}
