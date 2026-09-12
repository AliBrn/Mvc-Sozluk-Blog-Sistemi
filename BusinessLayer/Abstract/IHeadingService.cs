using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> HeadingList();
        void HeadingAdd(Heading heading);
        void HeadingRemove(Heading heading);    
        void HeadingUpdate(Heading heading);
        Heading  HeadingGetByID(int id); // Class döndürcen
    }
}
