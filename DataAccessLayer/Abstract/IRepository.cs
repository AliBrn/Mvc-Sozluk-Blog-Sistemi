using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    // Öncekinden farklı olarak öncekinde her class için bir abstract oluşturup  repositories oluşturuyorduk kategori,about,writer,heading duplicate oluyor
    // Bunun yerine napcaz bir tane interface oluşturuduk IRepository adında <T> dediğimiz varlık parametresiyle artık hangi class aitse ordan otomatik yapcaz
    // Bu sayede noldu  direk varlık gelmi gibi yapcaz öncesindeki categorydal interface hatalıydı orda category  yazıp repositiory ile çağrıyoduk
    public interface IRepository<T>    // Bu interface içini cONCRETE REPOSTORİESDEN gENERC rEPOSİTORYDEN DOLDURDUK
    {
        List<T> List();
        void Insert(T p);
        T Get(Expression<Func<T, bool>> filter); // Tek değer döndüren için bu metodu    ID si 5 no lu yazar dediğinde bunu kullanırız 
        void Update(T p);
        void Delete(T p);

        List<T> List(Expression<Func<T, bool>> filter); // Şartlı listelemeyi yapcak   Komple liste dönerken
    }
}
