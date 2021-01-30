using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities
{
    public class Schedule_Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Schedule_Type { get; set; }
        public int Workstation_Id { get; set; }
        public int Shift_Type { get; set; }
        public int PartSet_Id { get; set; }
        public int Required_Quantity { get; set; }
        public string Schedule_Start_Date { get; set; }
        public string Schedule_End_Date { get; set; }
        public int Status { get; set; }
        public Nullable<int> Created_By { get; set; }
        public Nullable<int> Modified_By { get; set; }
        public Nullable<System.DateTime> Date_Created { get; set; }
        public Nullable<System.DateTime> Date_Modified { get; set; }
    }
}
