using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebAPI.Services;
using WebAPI.Entities;
using Newtonsoft.Json;
using System.Linq;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
		private ICustomerService _customerService;

		public CustomerController(
			ICustomerService customerService)
		{
			_customerService = customerService;
		}

        [HttpGet]
        [Route("/Customer/GetCustomerList")]
        public string GetCustomerList()
        {
            IEnumerable<object> customerList = _customerService.GetCustomerList();
            return JsonConvert.SerializeObject(customerList);
        }
    }
}