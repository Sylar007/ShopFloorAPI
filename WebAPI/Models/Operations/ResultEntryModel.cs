using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Operations
{
    public class ResultEntryModel
    {
        public int operator_entry_id { get; set; }
        public int part_id { get; set; }
        public int result { get; set; }
    }
}
