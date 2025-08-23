namespace dotnet_store.Models;
public class Urun
{
    public int Id { get; set; }
    public string? UrunAdı { get; set; }
    public double Fiyat { get; set; }
    public bool Aktif { get; set; }
}