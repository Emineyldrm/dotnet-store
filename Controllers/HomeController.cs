using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnet_store.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Controllers;

public class HomeController : Controller
{
    private readonly DataContext _context;
    public HomeController(DataContext context)
    {
        _context = context;
    }
    public ActionResult Index()
    {
        //List<Urun> urunler = _context.Urunler.ToList(); 
        var urunler = _context.Urunler.Where(urun => urun.Aktif && urun.Anasayfa && true).ToList();
        ViewData["Katagoriler"]= _context.Kategoriler.ToList(); //katagorilere ulaşabiliyoruz
        return View(urunler);
    }   

    
}
