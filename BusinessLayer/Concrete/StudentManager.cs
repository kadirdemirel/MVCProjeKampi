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
    public class StudentManager : IStudentService
    {
        private IStudentDal _studentDal;
        private ITalentDal _talentDal;
        public StudentManager(IStudentDal studentDal, ITalentDal talentDal)
        {
            _studentDal = studentDal;
            _talentDal = talentDal;
        }
        public Student GetById(int studentId)
        {
            return _studentDal.Get(x => x.StudentId == studentId);
        }

        public List<Student> GetList()
        {
            var result = _studentDal.List();
            foreach (var item in result)
            {
                item.Talents = _talentDal.List(x => x.StudentId == item.StudentId);
            }
            return result;
        }

        public void StudentAdd(Student student)
        {
            _studentDal.Insert(student);
        }

        public void StudentDelete(Student student)
        {
            _studentDal.Delete(student);
        }

        public void StudentUpdate(Student student)
        {
            _studentDal.Update(student);
        }
    }
}
