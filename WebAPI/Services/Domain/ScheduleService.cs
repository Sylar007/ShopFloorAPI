using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Helpers;
using WebAPI.Models.Parts;
using WebAPI.Models.Schedule;

namespace WebAPI.Services
{
    public class ScheduleService : IScheduleService
    {
        private DataContext _context;

        public ScheduleService(DataContext context)
        {
            _context = context;
        }
        public dynamic GetScheduleJobById(int id)
        {
            try
            {
                var schedule_job = (from schedulejob in _context.Schedule_Jobs
                             join production_types in _context.Production_Types on schedulejob.Schedule_Type equals production_types.Id
                             join shift_types in _context.Shift_Types on schedulejob.Shift_Type equals shift_types.Id
                             join workstations in _context.WorkStations on schedulejob.Workstation_Id equals workstations.Id
                             where schedulejob.Id == id
                             select new
                             {
                                 id = schedulejob.Id,
                                 scheduleType = production_types.Name,
                                 shiftType = shift_types.Name,
                                 workstationName = workstations.Name,
                                 startDate = schedulejob.Schedule_Start_Date,
                                 endDate = schedulejob.Schedule_End_Date,
                                 partset_id = schedulejob.PartSet_Id,
                                 requiredQuantity = schedulejob.Required_Quantity
                             }).First();

                SchedulePartModel schedulepartmodel = new SchedulePartModel();
                schedulepartmodel.id = schedule_job.id;
                schedulepartmodel.scheduleType = schedule_job.scheduleType;
                schedulepartmodel.shiftType = schedule_job.shiftType;
                schedulepartmodel.workstationName = schedule_job.workstationName;
                schedulepartmodel.startDate = schedule_job.startDate;
                schedulepartmodel.endDate = schedule_job.endDate;
                schedulepartmodel.requiredQuantity = schedule_job.requiredQuantity;

                var parts = (from part in _context.Parts
                             join partset_details in _context.PartSet_Details on part.Id equals partset_details.Part_Id
                             join file_media in _context.File_Media on part.Id equals file_media.Part_Id
                             where partset_details.PartSet_Id == schedule_job.partset_id
                             select new
                             {
                                 id = part.Id,
                                 name = part.Part_Name,
                                 file_url = "assets/upload/" + file_media.File_Name + file_media.File_Type
                             }).ToList();
                List<Parts> partParents = new List<Parts>();
                foreach (var part in parts)
                {
                    Parts partSingle = new Parts();
                    partSingle.id = part.id;
                    partSingle.name = part.name;
                    partSingle.file_url = part.file_url;
                    partParents.Add(partSingle);
                }

                schedulepartmodel.parts = partParents;
                return schedulepartmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public dynamic GetEntryScheduleJobById(int id)
        {
            try
            {
                var parts = (from part in _context.Parts
                             join file_media in _context.File_Media on part.Id equals file_media.Part_Id
                             join operation_details in _context.Operator_Entry_Details on part.Id equals operation_details.Part_Id 
                             where operation_details.Operator_Entry_Id == id
                             select new
                             {
                                 id = part.Id,
                                 name = part.Part_Name,
                                 comply = operation_details.Comply,
                                 not_comply = operation_details.Not_Comply,
                                 file_url = "assets/upload/" + file_media.File_Name + file_media.File_Type
                             }).ToList();
                List<PartSchedule> partSchedules = new List<PartSchedule>();
                foreach (var part in parts)
                {
                    PartSchedule partSingle = new PartSchedule();
                    partSingle.id = part.id;
                    partSingle.name = part.name;
                    partSingle.file_url = part.file_url;
                    partSingle.comply = part.comply;
                    partSingle.not_comply = part.not_comply;
                    partSchedules.Add(partSingle);
                }
                return partSchedules;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public dynamic GetTechnicianById(int id)
        {
            try
            {
                var technicianEntry = (from schedule in _context.Schedule_Jobs
                             join production_types in _context.Production_Types on schedule.Schedule_Type equals production_types.Id
                             join shift_types in _context.Shift_Types on schedule.Shift_Type equals shift_types.Id
                             join workstations in _context.WorkStations on schedule.Workstation_Id equals workstations.Id
                             join operations in _context.Operations on schedule.Id equals operations.Schedule_Id
                             join operationdetails in _context.OperationDetails on operations.Id equals operationdetails.Operation_Id
                             join flows in _context.Flows on operations.WorkStation_Status equals flows.Id
                             where operations.Schedule_Id == id
                             orderby schedule.Date_Created descending
                             select new
                             {
                                 id = schedule.Id,
                                 station_name = workstations.Name,
                                 schedule_name = production_types.Name,
                                 shift_name = shift_types.Name,                                 
                                 startDate = schedule.Schedule_Start_Date,
                                 endDate = schedule.Schedule_End_Date,
                                 flow_id = flows.Id,
                                 parameter = operationdetails.Parameter,
                                 recommendation = operationdetails.Recommendation,
                             }).LastOrDefault();               
                return technicianEntry;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> OpenScheduleJobList()
        {
            try
            {
                var query = (from schedule in _context.Schedule_Jobs
                             join production_types in _context.Production_Types on schedule.Schedule_Type equals production_types.Id
                             join shift_types in _context.Shift_Types on schedule.Shift_Type equals shift_types.Id
                             join workstations in _context.WorkStations on schedule.Workstation_Id equals workstations.Id
                             orderby schedule.Date_Created descending
                             select new
                             {
                                 id = schedule.Id,
                                 scheduleType = production_types.Name,
                                 shiftType = shift_types.Name,
                                 workstationName = workstations.Name,
                                 startDate = schedule.Schedule_Start_Date,
                                 endDate = schedule.Schedule_End_Date,
                                 partset_id = schedule.PartSet_Id,
                                 requiredQuantity = schedule.Required_Quantity
                             }).ToList();
                IList<SchedulePartModel> scheduleJobs = new List<SchedulePartModel>();
                foreach (var parent in query)
                {
                    SchedulePartModel schedulepartmodel = new SchedulePartModel();
                    schedulepartmodel.id = parent.id;
                    schedulepartmodel.scheduleType = parent.scheduleType;
                    schedulepartmodel.shiftType = parent.shiftType;
                    schedulepartmodel.workstationName = parent.workstationName;
                    schedulepartmodel.startDate = parent.startDate;
                    schedulepartmodel.endDate = parent.endDate;
                    schedulepartmodel.requiredQuantity = parent.requiredQuantity;

                    var parts = (from part in _context.Parts
                                 join partset_details in _context.PartSet_Details on part.Id equals partset_details.Part_Id
                                 where partset_details.PartSet_Id == parent.partset_id
                                 select new
                                 {
                                     name = part.Part_Name
                                 }).ToList();
                    List<Parts> partParents = new List<Parts>();
                    foreach (var part in parts)
                    {
                        Parts partSingle = new Parts();
                        partSingle.name = part.name;
                        partParents.Add(partSingle);
                    }

                    schedulepartmodel.parts = partParents;
                    scheduleJobs.Add(schedulepartmodel);
                }
                return scheduleJobs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> OpenOperationTechnicianList()
        {
            try
            {
                var query = (from schedule in _context.Schedule_Jobs
                             join production_types in _context.Production_Types on schedule.Schedule_Type equals production_types.Id
                             join shift_types in _context.Shift_Types on schedule.Shift_Type equals shift_types.Id
                             join workstations in _context.WorkStations on schedule.Workstation_Id equals workstations.Id
                             orderby schedule.Date_Created descending
                             select new
                             {
                                 id = schedule.Id,
                                 scheduleType = production_types.Name,
                                 shiftType = shift_types.Name,
                                 workstationName = workstations.Name,
                                 startDate = schedule.Schedule_Start_Date,
                                 endDate = schedule.Schedule_End_Date,
                                 partset_id = schedule.PartSet_Id
                             }).ToList();
                IList<OperationTechnicianModel> operationTechnicians = new List<OperationTechnicianModel>();
                foreach (var parent in query)
                {
                    OperationTechnicianModel operationTechnician = new OperationTechnicianModel();
                    operationTechnician.id = parent.id;
                    operationTechnician.scheduleType = parent.scheduleType;
                    operationTechnician.shiftType = parent.shiftType;
                    operationTechnician.workstationName = parent.workstationName;
                    operationTechnician.startDate = parent.startDate;
                    operationTechnician.endDate = parent.endDate;

                    var parts = (from part in _context.Parts
                                 join partset_details in _context.PartSet_Details on part.Id equals partset_details.Part_Id
                                 join operations in _context.Operations on partset_details.PartSet_Id equals operations.PartSet_Id
                                 join flows in _context.Flows on operations.WorkStation_Status equals flows.Id
                                 where partset_details.PartSet_Id == parent.partset_id
                                 select new
                                 {
                                     name = part.Part_Name,
                                     station_status = flows.Name
                                 }).ToList();
                    List<Parts_Technician> partParents = new List<Parts_Technician>();
                    foreach (var part in parts)
                    {
                        Parts_Technician partSingle = new Parts_Technician();
                        partSingle.name = part.name;
                        operationTechnician.workstationStatus = part.station_status;
                        partParents.Add(partSingle);
                    }                    
                    operationTechnician.parts = partParents;
                    operationTechnicians.Add(operationTechnician);
                }
                return operationTechnicians;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public dynamic GetScheduleById(int id)
        {
            try
            {
                var schedule_job = (from schedulejob in _context.Schedule_Jobs
                                    join production_types in _context.Production_Types on schedulejob.Schedule_Type equals production_types.Id
                                    join shift_types in _context.Shift_Types on schedulejob.Shift_Type equals shift_types.Id
                                    join part_set in _context.PartSets on schedulejob.PartSet_Id equals part_set.Id
                                    join workstations in _context.WorkStations on schedulejob.Workstation_Id equals workstations.Id
                                    where schedulejob.Id == id
                                    select new
                                    {
                                        id = schedulejob.Id,
                                        scheduleType_id = production_types.Id,
                                        scheduleType_name = production_types.Name,
                                        shift_id = shift_types.Id,
                                        shift_name = shift_types.Name,
                                        workstation_id = workstations.Id,
                                        workstation_name = workstations.Name,
                                        schedule_StartDate = schedulejob.Schedule_Start_Date,
                                        schedule_EndDate = schedulejob.Schedule_End_Date,
                                        partSet_Id = schedulejob.PartSet_Id,
                                        partSet_Code = part_set.PartSet_Code,
                                        required_Quantity = schedulejob.Required_Quantity
                                    }).First();
                return schedule_job;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int EditSchedule(Schedule_Job data)
        {
            try
            {
                Schedule_Job schedule_job = _context.Schedule_Jobs.Where(x => x.Id == data.Id).First();
                schedule_job.Id = data.Id;
                schedule_job.Date_Modified = data.Date_Modified;
                schedule_job.Modified_By = data.Modified_By;
                schedule_job.PartSet_Id = data.PartSet_Id;
                schedule_job.Required_Quantity = data.Required_Quantity;
                schedule_job.Schedule_End_Date = data.Schedule_End_Date;
                schedule_job.Schedule_Start_Date = data.Schedule_Start_Date;
                schedule_job.Schedule_Type = data.Schedule_Type;
                schedule_job.Shift_Type = data.Shift_Type;
                schedule_job.Workstation_Id = data.Workstation_Id;
                int num = _context.SaveChanges();
                if (num > 0)
                {
                    return data.Id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data.Id;
        }
        public int AddSchedule(Schedule_Job data)
        {
            try
            {
                _context.Schedule_Jobs.Add(data);
                int num = _context.SaveChanges();
                if (num > 0)
                {
                    Operation operationData = new Operation();
                    operationData.PartSet_Id = data.PartSet_Id;
                    operationData.User_Id = (int) data.Created_By;
                    operationData.WorkStation_Status = 8;
                    operationData.Schedule_Id = data.Id;
                    _context.Operations.Add(operationData);
                    int numOperation = _context.SaveChanges();
                    OperationDetail operationdetailData = new OperationDetail();
                    operationdetailData.Operation_Id = operationData.Id;
                    operationdetailData.Flow = 8;
                    operationdetailData.Assigned_User = operationData.User_Id;
                    operationdetailData.Operation_Date = data.Date_Created;
                    _context.OperationDetails.Add(operationdetailData);
                    _context.SaveChanges();
                    return data.Id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data.Id;
        }
        public int EditTechnician(TechnicianModel data)
        {
            try
            {
                Operation operation = _context.Operations.Where(x => x.Schedule_Id == data.id).First();
                operation.WorkStation_Status = data.flow_id;
                int num = _context.SaveChanges();
                if (num > 0)
                {
                    OperationDetail operationdetail = _context.OperationDetails.Where(x => x.Operation_Id == operation.Id).FirstOrDefault();
                    operationdetail.Operation_Date = DateTime.Now;
                    operationdetail.Parameter = data.parameter;
                    operationdetail.Recommendation = data.recommendation;
                    _context.SaveChanges();
                    return data.id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data.id;
        }
    }
}
