using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
        public void UpdateValueAbout(int id)
        {
            using (Context context = new Context())
            {
                (from a in context.Abouts
                 where a.AboutID == id
                 select a).ToList().ForEach(x => x.IsActivated = true);


                context.SaveChanges();
            }
        }

    }
}
