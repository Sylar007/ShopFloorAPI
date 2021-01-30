using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Parts
{
    public class PartSetsModel
    {
        public int id { get; set; }
        public string partset_code { get; set; }       
        public List<PartSet_Part> parts { get; set; }
    }
    public class PartSet_Part
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
