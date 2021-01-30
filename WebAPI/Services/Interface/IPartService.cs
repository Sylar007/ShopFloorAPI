using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public interface IPartService
    {
        //dynamic GetPartBySerialNo(string serialNo);
        IEnumerable<dynamic> GetPartList();
        dynamic GetPartById(int id);
        int EditPart(Part data);
        int AddPart(Part data);
        //IEnumerable<dynamic> GetPartModelSelection();
        IEnumerable<dynamic> GetPartSetSelection();
    }
}
