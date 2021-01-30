using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities
{
    public class OperationDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Operation_Id { get; set; }
        public int Assigned_User { get; set; }
        public int Flow { get; set; }
        public string Parameter { get; set; }
        public string Recommendation { get; set; }
        public Nullable<System.DateTime> Operation_Date { get; set; }
    }
}
