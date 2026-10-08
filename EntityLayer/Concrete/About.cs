using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    // Concrete Somut sınıfları tutumak için oldugumuz klasörler soyut sınıf yerine somutları burda topluyoruz
    // Entity Framewrok  nugetpackages yükledik   
    public class About
    {
        [Key]
        public int AboutID { get; set; }


        [StringLength(1000)]
        public string AboutDetails1 { get; set; }

        [StringLength(1000)]
        public string AboutDetails2 { get; set; }

        [StringLength(100)]  // Alttaki niteliğin  kısıtlama uzunluğunu söyler
        public string AboutImage1 { get; set; }

        [StringLength(100)]
        public string AboutImage2 { get;set; }
        public bool AboutStatus { get; set; }
    }
}
