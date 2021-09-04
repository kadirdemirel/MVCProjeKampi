using BusinessLayer.Abstract;

using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ManagerManager : IManagerService
    {
        IAdminDal _adminDal;
        public ManagerManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public void AdminAdd(Admin admin)
        {

            _adminDal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _adminDal.Delete(admin);
        }


        public void AdminUpdate(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public Admin GetById(int adminId)
        {
            return _adminDal.Get(x => x.AdminId == adminId);
        }

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }
        public void IsActivatedFalse(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public void IsActivatedTrue(Admin admin)
        {
            _adminDal.Update(admin);
        }

        
    }
}
