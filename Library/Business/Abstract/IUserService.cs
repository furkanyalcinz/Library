﻿using Business.ReturnTypes;
using Business.Schema.User;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        public IResult Register(User user);
        public IResult Login(LoginSchema loginSchema);
        public int GetUserIdByEmail(string email);
    }
}
