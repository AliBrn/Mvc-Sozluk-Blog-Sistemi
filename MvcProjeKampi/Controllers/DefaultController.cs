using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    // En üsteki MvcProjeKampi aslında web katmanı ya da user interface ya da  presentation  controller model views barındırgı için .
    public class DefaultController : Controller
    {
        // Model Veritabanına ait entity dediğimi kavramlar
        // View  frontend  kısmı
        // Controller ise backend kısmı  view ile model arasındaki bağlantı
        // Controller da bir şey değiştirdidğin proje yeniden derlemek gerekir onun dışında  zaten yenilersen düzelir
        // Render body aslında diyorki  layout oluşturdun güzelde bu oluşturdugun layoutda   bir sayfaya eklediğinde sayfanını hangi kısmını getirceğim
        // sorusuna yanıt niteliğinde. rENDERBODY NEREYE YAZARSAN SAYFANINI O KISMINA İÇERİĞİ GETİRİ
        // rAZOR SYNTAXI  HTML DOSYASINDA  @ İLE BAŞLAYAN YAZMA STİLİ  div=> division (bölüm  anlamında)
        // GET: Default 


        // N katmanlı mimari ile çalışcağız
        // 1- Entity Layer 
        // 2- Data Access Layer
        // 3-Business Layer
        // 4-Presentation Layer- User Interface   MvcProjeKampi burası

        // 1- Entity Layer Verilerin tabloların property classların tanımladıgı yer  hangi class ismi
        // class nitelikleri 


        // 2-Data Access Layer  Veri ile ilgili temel işlemlerin yapıldıgı yer 
        // Temel crud =>  ekleme,silme,güncelleme,filtreleme gibi  işlemler  yapılır

        // 3- Business Layer  Veriler nasıl listelenceği koşullar  sınırlar
        // kaç karakter olcağı  hangi müşteri ne arar kim neye erişebilceğini

        // 4- Presentation Kullanıcının Gördüğü
        // katman ilk mvc yapımız zaten

        // Katmanları solution üzerinden class library .net framework seçtik her bir katmanı oluşturduk yapı bu şekilde.

        public ActionResult Index()
        {
            return View();
        }
    }
}