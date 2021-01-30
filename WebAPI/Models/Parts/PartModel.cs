using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Parts
{
    public class PartModel
    {
        public int id { get; set; }
        public string hil_code { get; set; }
        public string part_name { get; set; }
        public string part_no { get; set; }
        public int customer_id { get; set; }
        public string material_code { get; set; }
        public string material_description { get; set; }
        public string color { get; set; }
        public string back_code { get; set; }
        public string model { get; set; }
        public int status { get; set; }
    }
}
