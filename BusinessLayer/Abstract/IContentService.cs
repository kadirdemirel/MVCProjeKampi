using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IContentService
    {
        List<Content> GetList();
        void ContentAdd(Content content);
        Content GetById(int contentId);
        void ContentDelete(Content content);
        void ContentEdit(Content content);
        void ContentUpdate(Content content);
        int TotalContent(int contentId);
        List<Content> getListById(int id);
    }
}
