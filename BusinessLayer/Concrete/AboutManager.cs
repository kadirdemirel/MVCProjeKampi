using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;
        
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }
        public void AboutAdd(About about)
        {
            _aboutDal.Insert(about);
        }

        public void AboutDelete(About about)
        {
            _aboutDal.Delete(about);
        }

        public void AboutUpdate(About about)
        {
            _aboutDal.Update(about);
        }

        public About GetById(int aboutId)
        {
            return _aboutDal.Get(x => x.AboutID == aboutId);
        }

        public List<About> GetList()
        {
            return _aboutDal.List();
        }

        public void IsActivatedFalse(About about)
        {
            _aboutDal.Update(about);
        }

        public void IsActivatedTrue(About about)
        {
            _aboutDal.Update(about);
        }

        public void UpdateValueAbout(int id)
        {
            _aboutDal.UpdateValueAbout(id);
        }
    }
}
