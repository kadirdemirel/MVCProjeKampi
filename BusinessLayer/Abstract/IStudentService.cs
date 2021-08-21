using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStudentService
    {
        List<Student> GetList();
        void StudentAdd(Student student);
        Student GetById(int student);
        void StudentDelete(Student student);
        void StudentUpdate(Student student);
    }
}
