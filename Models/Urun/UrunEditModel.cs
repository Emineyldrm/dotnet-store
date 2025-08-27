using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class UrunEditModel
{
    public int Id { get; set; }
    [Display(Name = "Urun Adı")]
    public string UrunAdi { get; set; } = null!;
    [Display(Name = "Urun Açıklama")]
    public string urunAciklama { get; set; } = null!;
    [Display(Name = "Resim")]
    public string UrunResim { get; set; } = null!;
    [Display(Name = "Fiyat")]    
    public double UrunFiyat { get; set; }
    [Display(Name = "Aktif")]
    public bool UrunAktif { get; set; }
    [Display(Name = "Anasayfa")]
    public bool UrunAnasayfa { get; set; }
    public int KategoriId { get; set; } 
}