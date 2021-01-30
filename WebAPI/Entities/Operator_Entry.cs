using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities
{
    public class Operator_Entry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Schedule_Job_Id { get; set; }
        public Nullable<System.DateTime> Entry_Date { get; set; }
        public int Entry_Status { get; set; }
        public int User_Id { get; set; }
    }
}
