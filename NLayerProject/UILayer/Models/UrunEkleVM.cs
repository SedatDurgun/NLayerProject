using System.ComponentModel.DataAnnotations;

namespace UILayer.Models
{
    public class UrunEkleVM
    {
        [Display(Name ="Ürün Adı")] // Bu Kod ile view kısmında bulunan isimleri özelleştirebiliriz
        public string UrunAdi { get; set; }

        public string Acıklama { get; set; }

        public decimal Fiyat { get; set; }

        public IFormFile? Resim { get; set; } // IFormFile ile dosya seçimini yapabiliriz

        [Display(Name ="Ürün Videosu")]
        public IFormFile? UrunVideo { get; set; }  // ? ile birlikte ekrana zorunlu alan olmadığını  belirtiyoruz

        [Display(Name ="Kategori")]
        public int KategoriID { get; set; }
    }
}
