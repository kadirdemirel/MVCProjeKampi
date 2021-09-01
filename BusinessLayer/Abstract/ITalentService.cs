using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITalentService
    {
        List<Talent> GetList();
        Talent GetById(int talentId);
        void AddTalent(Talent talent);
        void DeleteTalent(Talent talent);
        void UpdateTalent(Talent talent);
    }
}
