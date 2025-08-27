using dotnet_store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class KategoriController : Controller
{
    private readonly DataContext _context;
    public KategoriController(DataContext context)
    {
        _context = context;
    }
    public ActionResult Index()
    {
        //var kategoriler=_context.Kategoriler.Include(i => i.Uruns).ToList();
        var kategoriler = _context.Kategoriler.Select(i => new KategoriGetModel
        {
            Id = i.Id,
            Url = i.Url,
            KategoriAdi = i.KategoriAdi,
            UrunSayisi = i.Uruns.Count
        }).ToList();


        return View(kategoriler);
    }
    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public ActionResult Create(KategoriCreateModel model)
    {
        var entity = new Kategori
        {
            KategoriAdi = model.KategoriAdi,
            Url = model.Url
        };
        _context.Kategoriler.Add(entity);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    public ActionResult Edit(int id)
    {
        var entity = _context.Kategoriler.Select(i => new KategoriEditModel
        {
            Id = i.Id,
            Url = i.Url,
            KategoriAdi = i.KategoriAdi,

        }).FirstOrDefault(i => i.Id == id);
        return View(entity);
    }
    [HttpPost]
    public ActionResult Edit(int id, KategoriEditModel model)
    {//route dan gelecek id ve modelimiz içerisinde olan Id
        if (id != model.Id)
        {
            //return NotFound();
            return View("Index");
        }
        var entity = _context.Kategoriler.FirstOrDefault(i=>i.Id==model.Id);
        if (entity != null)
        {
            //Modelden aldığımız bilgileri ile entity bilgilerini yani Kategori bilgilerini güncelliyoruz.
            //Yani edit yapacağımız value bilgileri ile veritabaındaki bilgiler değişecek.
            entity.Url = model.Url;
            entity.KategoriAdi = model.KategoriAdi;
            _context.SaveChanges(); //update sorgusu sql olarak veritabanına gönderilir

            // ViewData["Mesaj"] = $"{entity.KategoriAdi} kategorisi güncellendi. "; 
            //farklı bir yere yönlendirme olduğu için ulaşılmıyor.
            //Edit den Index sayfasına metot yönlendirme yapacak dolayısıyla çalışmaz ViewData, TempData kullanılırsa çalışır.
           TempData["Mesaj"] = $"{entity.KategoriAdi} kategorisi güncellendi. ";
            return RedirectToAction("Index");
        }
        return View(model);
    }

    
}