using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities
{
    public class Part
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Hil_Code { get; set; }
        public string Part_Name { get; set; }
        public string Part_No { get; set; }
        public int Customer_Id { get; set; }
        public string Material_Code { get; set; }
        public string Material_Description { get; set; }
        public string Colour { get; set; }
        public string Back_Code { get; set; }
        public string Model { get; set; }
        public int Media_Id { get; set; }
        public int Status { get; set; }
    }
}
