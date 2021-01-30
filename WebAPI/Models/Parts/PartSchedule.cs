using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Parts
{
    public class PartSchedule
    {
        public int id { get; set; }
        public string name { get; set; }
        public string file_url { get; set; }
        public int comply { get; set; }
        public int not_comply { get; set; }
    }
}
