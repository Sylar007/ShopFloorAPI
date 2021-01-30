using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities
{
    public class File_Media
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string File_Name { get; set; }
        public string File_Url { get; set; }
        public string File_Type { get; set; }
        public string Content_Type { get; set; }
        public int Part_Id { get; set; }
    }
}
