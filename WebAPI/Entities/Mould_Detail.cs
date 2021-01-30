using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities
{
    public class Mould_Detail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Mould_Id { get; set; }
        public int Part_Id { get; set; }
        public int PartMould_Type_Id { get; set; }
        public int Status { get; set; }
    }
}
