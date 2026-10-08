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
        IImageFileDal _imageFileDal;

        public ImageFileManager(IImageFileDal imagefiledal)
        {
          _imageFileDal = imagefiledal;
        }
        public List<ImageFile> GetImageFileList()
        {
            return  _imageFileDal.List();
        }
    }
}
