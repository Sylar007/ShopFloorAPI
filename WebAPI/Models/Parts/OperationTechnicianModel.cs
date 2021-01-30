using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Parts
{
    public class OperationTechnicianModel
    {
        public int id { get; set; }
        public string station_name { get; set; }
        public string shiftType { get; set; }
        public string scheduleType { get; set; }
        public string workstationName { get; set; }
        public List<Parts_Technician> parts { get; set; }
        public string workstationStatus { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
    public class Parts_Technician
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
