using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebAPI.Services;
using WebAPI.Entities;
using Newtonsoft.Json;
using System.Linq;
using WebAPI.Models.Operations;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class OperationEntryController : ControllerBase
    {
		private IOperationEntryService _operationentryService;

		public OperationEntryController(
            IOperationEntryService operationentryService)
		{
            _operationentryService = operationentryService;
		}

		[HttpPost]
		[Route("/OperationEntry/UpdateEntry")]
		public int UpdateEntry([FromBody] OperationEntryModel model)
		{
			Operator_Entry operator_entry = new Operator_Entry();
			operator_entry.Id = model.id;
			operator_entry.Schedule_Job_Id = model.schedule_job_id;
			int idClaim = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type.Equals("assigned_User_Id", StringComparison.InvariantCultureIgnoreCase)).Value);
			operator_entry.User_Id = idClaim; 

			return _operationentryService.EditEntry(operator_entry);
		}

		[HttpPost]
		[Route("/OperationEntry/AddEntry")]
		public int AddEntry([FromBody] OperationEntryModel model)
		{
			Operator_Entry operator_entry = new Operator_Entry();
			operator_entry.Schedule_Job_Id = model.schedule_job_id;
			int idClaim = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type.Equals("assigned_User_Id", StringComparison.InvariantCultureIgnoreCase)).Value);
			operator_entry.User_Id = idClaim;
			operator_entry.Entry_Status = 0;
			operator_entry.Entry_Date = DateTime.Now;
			return _operationentryService.AddEntry(operator_entry);
		}


		[HttpPost]
		[Route("/OperationEntry/EntryDetails")]
		public bool EntryDetails([FromBody] List<ResultEntryModel> models)
		{
			List<Operator_Entry_Detail> operator_entry_details = new List<Operator_Entry_Detail>();
			foreach (ResultEntryModel model in models)
			{
				Operator_Entry_Detail operator_entry_detail = new Operator_Entry_Detail();
				operator_entry_detail.Operator_Entry_Id = model.operator_entry_id;
				operator_entry_detail.Part_Id = model.part_id;
				if (model.result == 0)
				{
					operator_entry_detail.Not_Comply = 1;
				}
				else
				{
					operator_entry_detail.Comply = 1;
				}
				
				operator_entry_details.Add(operator_entry_detail);
			}
			
			return _operationentryService.AddEntryDetails(operator_entry_details);
		}
	}
}