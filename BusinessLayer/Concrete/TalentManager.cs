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

        public void AddTalent(Talent talent)
        {
            _talentDal.Insert(talent);
        }

        public void DeleteTalent(Talent talent)
        {
            _talentDal.Delete(talent);
        }

        public Talent GetById(int talentId)
        {
            return _talentDal.Get(x => x.TalentId == talentId);
        }

        public List<Talent> GetList()
        {
            return _talentDal.List();
        }

        public void UpdateTalent(Talent talent)
        {
            _talentDal.Update(talent);
        }
    }
}
