using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public interface IReferencesService
    {
        IEnumerable<dynamic> GetStationList();
        IEnumerable<dynamic> GetShiftList();
        IEnumerable<dynamic> GetScheduleList();
        IEnumerable<dynamic> GetFlowList();
    }
}
