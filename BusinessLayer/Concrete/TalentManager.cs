using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TalentManager : ITalentService
    {
        ITalentDal _talentDal;
        public TalentManager(ITalentDal talentDal)
        {
            _talentDal = talentDal;
        }
        public Talent GetById(int talentId)
        {
            return _talentDal.Get(x => x.TalentId == talentId);
        }

        public List<Talent> GetList()
        {
            return _talentDal.List();
        }
    }
}
