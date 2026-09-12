using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    // CODE FIRST YAKLAŞIMI N KATMANLI MİMARİ YPAIYORUZ
    public class Heading
    {
        [Key]
        public int HeadingID { get; set; }

        [StringLength(50)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }

        public bool HeadingStatus { get; set; }

        //    Çok olan bu taraf buna göre  Category Id si olcak hepsinin
        public int CategoryID { get; set; } // Eşşiz kimlik çok olanda 
        public virtual Category Category { get; set; }

        // Başlık ve içerikde  1-n  ilişki var   birden fazla barındıran heading  
        public  ICollection<Content> Contents { get; set; }

        // Başlık ve yazar ilişkisi ID kısmı başlıgı açanın ve ayrıca writer erişmemimizi sağlayan
        public int WriterID { get; set; }   
        public virtual Writer Writer { get; set; }

        // Bu kısımda 1 numarali  başlık id  entity framewework başlık adı  13.04 tarihinde oluşturulup  2 numaralı categorysi ıd var  5 numaralı yazar ıd
        //  Content yok   Heading içinde  id olanlar görürsün
    }
}
