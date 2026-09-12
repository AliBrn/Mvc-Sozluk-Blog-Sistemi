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
        public void ContentAdd(Content cnt)
        {
            throw new NotImplementedException();
        }

        public Content ContentGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> ContentList()
        {
            throw new NotImplementedException();
        }

        public void ContentRemove(Content cnt)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdate(Content cnt)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetListByHeadingID(int id) // .List yazdıkya  aslında parametreli listeyi çağırdık .List(func expression ifadesi) olan çağırdık.
        {
            return _contentdal.List(x=>x.HeadingID==id); // Listele ama neye göre Heading id göre
        }
    }
}
