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
        public void Register(User user);
        public void Login(LoginSchema loginSchema);
    }
}
