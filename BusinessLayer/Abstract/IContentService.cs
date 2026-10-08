using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    /// <summary>
    /// İçerik (yazı) işlemleri için servis arayüzü
    /// </summary>
    public interface IContentService
    {
        void ContentUpdate(Content cnt);
        void ContentRemove(Content cnt);
        void ContentAdd(Content cnt);
        Content ContentGetByID(int id);
        List<Content> GetListByHeadingID(int id);
        List<Content> ContentList(string deger);
        List<Content> GetListByWriter(int id);
    }
}
