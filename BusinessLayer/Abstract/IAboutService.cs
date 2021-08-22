using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        void IsActivatedTrue(About about);
        void IsActivatedFalse(About about);
        void UpdateValueAbout(int id);
        List<About> GetList();
        void AboutAdd(About about);
        About GetById(int aboutId);
        void AboutDelete(About about);
        void AboutUpdate(About about);
    }
}
