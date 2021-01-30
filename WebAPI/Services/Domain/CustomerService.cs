using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Helpers;

namespace WebAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<dynamic> GetCustomerList()
        {
            try
            {
                return (from customer in _context.Customers                       
                        orderby customer.Customer_Name
                        select new
                        {
                            id = customer.Id,
                            customer_name = customer.Customer_Name
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
