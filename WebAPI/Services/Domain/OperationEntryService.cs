using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Helpers;

namespace WebAPI.Services
{
    public class OperationEntryService : IOperationEntryService
    {
        private DataContext _context;

        public OperationEntryService(DataContext context)
        {
            _context = context;
        }
        public int EditEntry(Operator_Entry data)
        {
            try
            {
                Operator_Entry operator_entry = _context.Operator_Entries.Where(x => x.Id == data.Id).First();
                operator_entry.Id = data.Id;
                operator_entry.Schedule_Job_Id = data.Schedule_Job_Id;
                operator_entry.User_Id = data.User_Id;
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

        public int AddEntry(Operator_Entry data)
        {
            try
            {
                _context.Operator_Entries.Add(data);
                int num = _context.SaveChanges();
                if (num > 0)
                {
                    Schedule_Job schedule_job = _context.Schedule_Jobs.Where(x => x.Id == data.Schedule_Job_Id).First();
                    List<PartSet_Detail> partset_details = _context.PartSet_Details.Where(x => x.PartSet_Id == schedule_job.PartSet_Id).ToList();
                    foreach(PartSet_Detail localPartSet_Detail in partset_details)
                    {
                        Operator_Entry_Detail operator_entry_detail = new Operator_Entry_Detail();
                        operator_entry_detail.Operator_Entry_Id = data.Id;
                        operator_entry_detail.Created_Date = DateTime.Now;
                        operator_entry_detail.Part_Id = localPartSet_Detail.Part_Id;
                        _context.Operator_Entry_Details.Add(operator_entry_detail);
                        _context.SaveChanges();
                    }                    
                    return data.Id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data.Id;
        }

        public bool AddEntryDetails(List<Operator_Entry_Detail> datas)
        {
            try
            {
                foreach(Operator_Entry_Detail data in datas)
                {
                    Operator_Entry_Detail operator_entry_detail = _context.Operator_Entry_Details.Where(x => x.Operator_Entry_Id == data.Operator_Entry_Id && x.Part_Id == data.Part_Id).First();
                    operator_entry_detail.Operator_Entry_Id = data.Operator_Entry_Id;
                    operator_entry_detail.Part_Id = data.Part_Id;
                    operator_entry_detail.Comply = data.Comply + operator_entry_detail.Comply;
                    operator_entry_detail.Not_Comply = data.Not_Comply + operator_entry_detail.Not_Comply;
                    operator_entry_detail.Modified_Date = DateTime.Now;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
