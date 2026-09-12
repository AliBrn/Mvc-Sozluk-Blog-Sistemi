using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfHeadingDal: GenericRepository<Heading>,IHeadingDal
    {
        // Tekrar amaçlı yazıyorum

        //  IREPOSİTORY metotların interface tanımlandıgı yer

        // Generic Repository IREPOSİTORY metotların  yani imzaların içinin dolduruldugu yer

        // IHeadingDal  metotların imzası olan Irepository kendi classı heading göre özelleşmesi Iheading özelleşmiş class

        // EFHeadingDal  =>Generic REPOSİTORY yani  içi doldurulmuş metotların  headinge özel olan kalıtım ve
        // IhEADİNG HEADİNG ÖZEL kalıtım aldıgı yer

        // GenericRepository "Class", Iheadingdal (IrEPOSİTORY göre  özel kalıtım almış yapı)
    }
}
