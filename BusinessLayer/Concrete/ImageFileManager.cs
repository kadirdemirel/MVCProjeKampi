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
    public class ImageFileManager : IImageFileService
    {
        private IImageFileDal _imageFileDal;
        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }

        public void AddImageFile(ImageFile imageFile)
        {
            _imageFileDal.Insert(imageFile);
        }

        public List<ImageFile> GetList()
        {
            return _imageFileDal.List();
        }
    }
}
