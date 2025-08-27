namespace dotnet_store.Models;

public class UrunGetModel
{
    public int Id { get; set; }
    public string UrunAdi { get; set; } = null!;
    public string? Resim { get; set; }
    // public string? Aciklama { get; set; }
    //kullanmadığımız ürünüde almaya gerek yok
    public double Fiyat { get; set; }
    public bool Aktif { get; set; }
    public bool Anasayfa { get; set; }

    //public int KategoriId { get; set; }
    public string KategoriAdi { get; set; } = null!;
}