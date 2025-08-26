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
        return View();
    }
    public ActionResult List(string url, string q)
    {
        //var query = _context.Urunler.AsQueryable();//Querylable
        var query = _context.Urunler.Where(i =>i.Aktif);//Querylable
        if (!string.IsNullOrEmpty(url))
        {
            //fitreleme, url nin dolu olduğu durum
            query = query.Where(i => i.Kategori.Url == url);
        }
        if (!string.IsNullOrEmpty(q))
        {
            //fitreleme q ' nun dolu olduğu durm
            query = query.Where(i => i.UrunAdi.ToLower().Contains(q.ToLower()));
            ViewData["q"] = q;
        }

        //List<Urun> urunler = _context.Urunler.ToList(); 
        //var urunler = _context.Urunler.Where(i => i.Aktif && i.Kategori.Url==url).ToList();
        //return View(urunler);
        return View(query.ToList());
    }

     public ActionResult Details(int id)
    {
        //var urun = _context.Urunler.FirstOrDefaultAsync( i => i.Id == id);
        //var urun = _context.Urunler.Where(i => i.Id == id).ToList();
        //var urun = _context.Urunler.Where(i => i.UrunAdi == "Iphone 16").FirstOrDefault();
        var urun = _context.Urunler.Find(id);
        if (urun == null)
        {
            // return RedirectToAction("List");
            return RedirectToAction("Index", "Home");
        
        }
        ViewData["Benzer Urunler"]=_context.Urunler
        .Where(i => i.Aktif && i.KategoriId == urun.KategoriId && i.Id != id)
        .Take(4)
        .ToList();

        return View(urun);
    }
}
