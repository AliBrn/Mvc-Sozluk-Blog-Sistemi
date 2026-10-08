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
    public class ContentManager : IContentService
    {
        IContentDal _contentdal;

        public ContentManager(IContentDal contentdal)
        {
            _contentdal = contentdal;
        }
        // Yeni içerik ekler
        public void ContentAdd(Content cnt)
        {
            _contentdal.Insert(cnt);
        }

        public Content ContentGetByID(int id)
        {
            throw new NotImplementedException();
        }

        // Arama parametresine göre veya tüm içerikleri listeler
        public List<Content> ContentList(string deger)
        {
            if (string.IsNullOrEmpty(deger))
            {
                return _contentdal.List();
            }

            return _contentdal.List(x => x.ContentValue.Contains(deger));
        }

        public void ContentRemove(Content cnt)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdate(Content cnt)
        {
            throw new NotImplementedException();
        }

        // Başlık ID'sine ait tüm içerikleri listeler
        public List<Content> GetListByHeadingID(int id)
        {
            return _contentdal.List(x => x.HeadingID == id);
        }

        // Yazar ID'sine ait tüm içerikleri listeler
        public List<Content> GetListByWriter(int id)
        {
            return _contentdal.List(x => x.WriterID == id);
        }



    }
}
