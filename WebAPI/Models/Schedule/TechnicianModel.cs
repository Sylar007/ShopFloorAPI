using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Schedule
{
    public class TechnicianModel
    {
        public int id { get; set; }
        public string station_name { get; set; }
        public string schedule_name { get; set; }
        public string shift_name { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int flow_id { get; set; }
        public string parameter { get; set; }
        public string recommendation { get; set; }
    }
}
