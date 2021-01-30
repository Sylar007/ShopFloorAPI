using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebAPI.Models.Schedule
{   
    public class ScheduleModel
    {
        public int id { get; set; }
        public int scheduleType_id { get; set; }
        public int shift_id { get; set; }
        public int workstation_id { get; set; }
        public int partSet_Id { get; set; }
        public string schedule_StartDate { get; set; }
        public string schedule_EndDate { get; set; }
        public int required_Quantity { get; set; }
    }
}
