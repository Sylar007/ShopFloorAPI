using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebAPI.Services;
using WebAPI.Entities;
using WebAPI.Models.Parts;
using Newtonsoft.Json;
using System.Linq;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PartController : ControllerBase
    {
		private IPartService _partService;

		public PartController(
			IPartService partService)
		{
			_partService = partService;
		}

		[HttpGet]
		[Route("/part/GetPartList")]
		public string GetPartList()
		{
			IEnumerable<object> part = _partService.GetPartList();
			return JsonConvert.SerializeObject(part);
		}
		[HttpGet]
		[Route("/part/GetPartSetSelection")]
		public string GetPartSetSelection()
		{
			IEnumerable<object> part = _partService.GetPartSetSelection();
			return JsonConvert.SerializeObject(part);
		}
		
		[HttpGet]
		[Route("/Part/GetPartById/{id}")]
		public string GetPartById(int id)
		{
			object part = _partService.GetPartById(id);
			return JsonConvert.SerializeObject(part);
		}

		[HttpPost]
		[Route("/Part/UpdatePart")]
		public int UpdatePart([FromBody] PartModel model)
		{
			Part part = new Part();			
			part.Id = model.id;
			part.Hil_Code = model.hil_code;
			part.Part_Name = model.part_name;
			part.Part_No = model.part_no;
			part.Customer_Id = model.customer_id;
			part.Material_Code = model.material_code;
			part.Material_Description = model.material_description;
			part.Colour = model.color;
			part.Back_Code = model.back_code;
			part.Model = model.model;
			return _partService.EditPart(part);
		}

		[HttpPost]
		[Route("/Part/AddPart")]
		public int AddPart([FromBody] PartModel model)
		{
			Part part = new Part();
			part.Hil_Code = model.hil_code;
			part.Status = 1;
			part.Part_Name = model.part_name;
			part.Part_No = model.part_no;
			part.Customer_Id = model.customer_id;
			part.Material_Code = model.material_code;
			part.Material_Description = model.material_description;
			part.Colour = model.color;
			part.Back_Code = model.back_code;
			part.Model = model.model;
			return _partService.AddPart(part);
		}

		//[HttpGet]
		//[Route("/Part/GetPartModelSelection")]
		//public string GetPartModelSelection()
		//{
		//	IEnumerable<object> partModelSelectionList = _partService.GetPartModelSelection();
		//	return JsonConvert.SerializeObject(partModelSelectionList);
		//}
	}
}