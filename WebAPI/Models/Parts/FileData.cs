using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Parts
{
    public class FileData
    {
        [Required]
        public IFormFile file { get; set; }
        [Required]
        public int id { get; set; }
    }
}
