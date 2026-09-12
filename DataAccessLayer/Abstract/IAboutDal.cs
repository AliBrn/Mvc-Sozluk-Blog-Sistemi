using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    // Generic Interface niçin kullandık  ilk yaptıgımız Category Dal hatırlıyorsun orda   Category dal içinde 4 tane metot tanımladık
    // Yok kategori ait listele yok kategori parametresine göre ekle şimdi her yeni bir class ona özgü interface  mi oluşturcaz
    //   Yarın   bilgi sayfası olcak ondada  List<Information> List()  void Insertt(Information i)  şeklinde metot tanımlamak duplicate ibaret
    // Bu yapıda kullansaydık zaten giden controllerda direk tekrarlardık bu hatalı oldugu için böyle yapmıycaz

    // Bunun yerine çözüm önerimiz ne IRepository.cs dosyasında  Irepository interface  Irepository<T> şeklinde varlık parametre olarak yolladık
    // Metotlarda da  void Insert(T p)  List<T> liste();  olarak yaparak  aslında  direkmen  burdan kalıtım alsa bir class otomatik tüm metotlar tanımlanmış olur

    // Bu yüzden Icategorydaldaki ilk kısım hatalıydı bunu bu şekilde çözdük

    // Böylece  Iaboutdal   kendine parametre about olanı alcak
    public interface IAboutDal:IRepository<About>  // KeNDİNE ÖZGÜ OLDUGUNU BELİRLEMEK İÇİN KULLANDIGIMIZ BİR YAPI  
    {
        // Genel ınterface oluşturduk  => Şimdi IABOUTDAL  kendi about ait sözleşme var
        // Genel interface   kullanan sınıf oluşturduk şimdi  kendine özgü işlemler olduklarını yapcaz
    }
}
