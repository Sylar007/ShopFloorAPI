using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebAPI.Services;
using WebAPI.Entities;
using Newtonsoft.Json;
using System.Linq;
using WebAPI.Models.Schedule;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ScheduleJobController : ControllerBase
    {
		private IScheduleService _schedulejobService;

		public ScheduleJobController(
            IScheduleService schedulejobService)
		{
            _schedulejobService = schedulejobService;
		}

        [HttpGet]
        [Route("/ScheduleJob/OpenScheduleJobList")]
        public string OpenScheduleJobList()
        {
            IEnumerable<object> schedulejobList = _schedulejobService.OpenScheduleJobList();
            return JsonConvert.SerializeObject(schedulejobList);
        }

        [HttpGet]
        [Route("/ScheduleJob/OpenOperationTechnicianList")]
        public string OpenOperationTechnicianList()
        {
            IEnumerable<object> operationtechnicianList = _schedulejobService.OpenOperationTechnicianList();
            return JsonConvert.SerializeObject(operationtechnicianList);
        }

        [HttpGet]
        [Route("/ScheduleJob/GetScheduleJobById/{id}")]
        public string GetScheduleJobById(int id)
        {
            object schedulejobList = _schedulejobService.GetScheduleJobById(id);
            return JsonConvert.SerializeObject(schedulejobList);
        }
        [HttpGet]
        [Route("/ScheduleJob/GetTechnicianById/{id}")]
        public string GetTechnicianById(int id)
        {
            object operationtechnicianList = _schedulejobService.GetTechnicianById(id);
            return JsonConvert.SerializeObject(operationtechnicianList);
        }

        [HttpGet]
        [Route("/ScheduleJob/GetEntryScheduleJobById/{id}")]
        public string GetEntryScheduleJobById(int id)
        {
            object schedulepartList = _schedulejobService.GetEntryScheduleJobById(id);
            return JsonConvert.SerializeObject(schedulepartList);
        }

        [HttpGet]
        [Route("/ScheduleJob/GetScheduleById/{id}")]
        public string GetScheduleById(int id)
        {
            object schedulejobList = _schedulejobService.GetScheduleById(id);
            return JsonConvert.SerializeObject(schedulejobList);
        }
        [HttpPost]
        [Route("/ScheduleJob/UpdateSchedule")]
        public int UpdateSchedule([FromBody] ScheduleModel model)
        {
            Schedule_Job schedule = new Schedule_Job();
            schedule.Id = model.id;
            schedule.PartSet_Id = model.partSet_Id;
            schedule.Required_Quantity = model.required_Quantity;
            schedule.Schedule_Type = model.scheduleType_id;
            schedule.Schedule_End_Date = model.schedule_EndDate;
            schedule.Schedule_Start_Date = model.schedule_StartDate;
            schedule.Shift_Type = model.shift_id;
            schedule.Workstation_Id = model.workstation_id;
            int idClaim = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type.Equals("assigned_User_Id", StringComparison.InvariantCultureIgnoreCase)).Value);
            schedule.Modified_By = idClaim;
            schedule.Date_Modified = DateTime.Now;
            return _schedulejobService.EditSchedule(schedule);
        }
        [HttpPost]
        [Route("/ScheduleJob/AddSchedule")]
        public int AddSchedule([FromBody] ScheduleModel model)
        {
            Schedule_Job schedule = new Schedule_Job();
            schedule.PartSet_Id = model.partSet_Id;
            schedule.Required_Quantity = model.required_Quantity;
            schedule.Schedule_Type = model.scheduleType_id;
            schedule.Schedule_End_Date = model.schedule_EndDate;
            schedule.Schedule_Start_Date = model.schedule_StartDate;
            schedule.Shift_Type = model.shift_id;
            schedule.Workstation_Id = model.workstation_id;
            int idClaim = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type.Equals("assigned_User_Id", StringComparison.InvariantCultureIgnoreCase)).Value);
            schedule.Created_By = idClaim;
            schedule.Date_Created = DateTime.Now;
            schedule.Status = 1;
            return _schedulejobService.AddSchedule(schedule);
        }
        [HttpPost]
        [Route("/ScheduleJob/UpdateTechnician")]
        public int UpdateTechnician([FromBody] TechnicianModel model)
        {
            return _schedulejobService.EditTechnician(model);
        }
    }
}