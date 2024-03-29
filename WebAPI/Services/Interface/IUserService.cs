﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        User AutoLogin(string username);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
        IEnumerable<dynamic> GetAssignSelection();
        bool CanAccess();
    }
}
