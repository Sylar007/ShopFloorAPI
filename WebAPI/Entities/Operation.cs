using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities
{
    public class Operation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PartSet_Id { get; set; }
        public int WorkStation_Status { get; set; }
        public int User_Id { get; set; }
        public int Schedule_Id { get; set; }
    }
}
