using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Models.Schedule;

namespace WebAPI.Services
{    
    public interface IScheduleService
    {
        IEnumerable<dynamic> OpenScheduleJobList();
        dynamic GetScheduleJobById(int id);
        dynamic GetEntryScheduleJobById(int id);
        dynamic GetScheduleById(int id);
        int EditSchedule(Schedule_Job data);
        int AddSchedule(Schedule_Job data);
        IEnumerable<dynamic> OpenOperationTechnicianList();
        dynamic GetTechnicianById(int id);
        int EditTechnician(TechnicianModel data);
    }
}
