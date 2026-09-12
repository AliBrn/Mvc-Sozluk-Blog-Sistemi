using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        void ContentUpdate(Content cnt);
        void ContentRemove(Content cnt);
        void ContentAdd(Content cnt);
        Content ContentGetByID(int id);
        List<Content> GetListByHeadingID(int id); // Bu listeyi koşula göre getirme için
        List<Content> ContentList();
    }
}
