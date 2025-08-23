using dotnet_store.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_store.Controllers;


public class UrunController : Controller
{
    //Dependecy Injection => DI
    private readonly DataContext _context;
    public UrunController(DataContext context)
    {
        _context = context;
    }
    public ActionResult Index()
    {
        //List<Urun> urunler = _context.Urunler.ToList(); 
        var urunler = _context.Urunler.ToList(); 
        return View(urunler);
    }
}
