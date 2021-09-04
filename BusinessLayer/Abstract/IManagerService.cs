using EntityLayer.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IManagerService
    {
        List<Admin> GetList();
        void AdminAdd(Admin admin);
        Admin GetById(int adminId);
        void AdminDelete(Admin admin);
        void AdminUpdate(Admin admin);
        void IsActivatedTrue(Admin admin);
        void IsActivatedFalse(Admin admin);
        


    }
}
