using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebAPI.Services;
using WebAPI.Entities;
using Newtonsoft.Json;
using System.Linq;
using System.ComponentModel.Design;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ReferenceController : ControllerBase
    {
        private IReferencesService _referenceService;

        public ReferenceController(
            IReferencesService referenceService)
        {
            _referenceService = referenceService;
        }
        [HttpGet]
        [Route("/Reference/GetStationList")]
        public string GetStationList()
        {
            IEnumerable<object> part = _referenceService.GetStationList();
            return JsonConvert.SerializeObject(part);
        }
        [HttpGet]
        [Route("/Reference/GetShiftList")]
        public string GetShiftList()
        {
            IEnumerable<object> part = _referenceService.GetShiftList();
            return JsonConvert.SerializeObject(part);
        }
        [HttpGet]
        [Route("/Reference/GetScheduleList")]
        public string GetScheduleList()
        {
            IEnumerable<object> part = _referenceService.GetScheduleList();
            return JsonConvert.SerializeObject(part);
        }
        [HttpGet]
        [Route("/Reference/GetFlowList")]
        public string GetFlowList()
        {
            IEnumerable<object> flow = _referenceService.GetFlowList();
            return JsonConvert.SerializeObject(flow);
        }
    }
}
