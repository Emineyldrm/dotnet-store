using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

//model
public class KategoriEditModel
{
    public int Id { get; set; }
    [Display(Name="KategoriAdı")]
    public string KategoriAdi { get; set; } = null!;
    [Display(Name="URL")]
    public string Url { get; set; } = null!;
}