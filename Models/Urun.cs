namespace dotnet_store.Models;

public class Urun
{
    public int Id { get; set; }
    public string UrunAdi { get; set; } = null!;
    public string Resim { get; set; } = null!;
    public string Aciklama { get; set; } = null!;
    public double Fiyat { get; set; }
    public bool Aktif { get; set; }
    public bool Anasayfa { get; set; }

    public int KategoriId { get; set; }
    public Kategori Kategori { get; set; } = null!;
}