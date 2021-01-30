using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Helpers;

namespace WebAPI.Services
{
    public class ReferencesService : IReferencesService
    {
        private DataContext _context;

        public ReferencesService(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<dynamic> GetStationList()
        {
            try
            {
                return (from station in _context.WorkStations
                        orderby station.Name
                        select new
                        {
                            id = station.Id,
                            station_name = station.Name
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetShiftList()
        {
            try
            {
                return (from shift in _context.Shift_Types
                        orderby shift.Name
                        select new
                        {
                            id = shift.Id,
                            shift_name = shift.Name
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetScheduleList()
        {
            try
            {
                return (from schedule in _context.Production_Types
                        orderby schedule.Name
                        select new
                        {
                            id = schedule.Id,
                            schedule_name = schedule.Name
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetFlowList()
        {
            try
            {
                return (from flow in _context.Flows
                        orderby flow.Name
                        select new
                        {
                            id = flow.Id,
                            flow_name = flow.Name
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
