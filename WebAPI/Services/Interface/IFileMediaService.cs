using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public interface IFileMediaService
    {
        int AddFile(File_Media fileData);
        File_Media GetMediaName(int part_id);
    }
}
