using System.Threading.Tasks;
using dotnet_store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
        var urunler = _context.Urunler.Select(i => new UrunGetModel
        {
            Id = i.Id,
            UrunAdi = i.UrunAdi,
            Resim = i.Resim,
            Fiyat = i.Fiyat,
            Aktif = i.Aktif,
            Anasayfa = i.Anasayfa,
            KategoriAdi = i.Kategori.KategoriAdi

        }).ToList();
        //var urunler = _context.Urunler.Include(i=>i.Kategori).ToList();
        return View(urunler);
    }
    public ActionResult List(string url, string q)
    {
        //var query = _context.Urunler.AsQueryable();//Querylable
        var query = _context.Urunler.Where(i => i.Aktif);//Querylable
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
        ViewData["Benzer Urunler"] = _context.Urunler
        .Where(i => i.Aktif && i.KategoriId == urun.KategoriId && i.Id != id)
        .Take(4)
        .ToList();

        return View(urun);
    }

    public ActionResult Create()
    {
        //ViewData["Kategoriler"]=_context.Kategoriler.ToList();
        //ViewBag.Kategoriler=_context.Kategoriler.ToList();
        ViewBag.Kategoriler = new SelectList(_context.Kategoriler.ToList(), "Id", "KategoriAdi");
        return View();

    }

    [HttpPost]
    public async Task<ActionResult> Create(UrunCreateModel model)
    {
        var filename = Path.GetRandomFileName() + ".jpg";
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Wwwrooot/img", filename);

        using (var stream = new FileStream(path, FileMode.Create)) {
            await model.UrunResim!.CopyToAsync(stream);
        }


        var entity = new Urun
        {
            UrunAdi = model.UrunAdi,
            Aciklama = model.urunAciklama,
            Fiyat = model.UrunFiyat,
            Aktif = model.UrunAktif,
            Anasayfa = model.UrunAnasayfa,
            Resim = filename, //upload
            KategoriId = model.KategoriId
        };
        _context.Urunler.Add(entity);
        _context.SaveChanges();
        return RedirectToAction("Index");
        //return View();
    }

    public ActionResult Edit(int id)
    {
        var entity = _context.Urunler.Select(i => new UrunEditModel
        {
            Id = i.Id,
            UrunAdi=i.UrunAdi,
            UrunFiyat=i.Fiyat,
            urunAciklama=i.Aciklama,
            UrunAktif=i.Aktif,
            UrunAnasayfa=i.Anasayfa,
            UrunResim=i.Resim,
            KategoriId = i.KategoriId, 
        }).FirstOrDefault(i => i.Id == id);
        ViewBag.Kategoriler = new SelectList(_context.Kategoriler.ToList(), "Id", "KategoriAdi");
        return View(entity);
    }
    [HttpPost]
      public ActionResult Edit(int id, UrunEditModel model)
    {
        if (id != model.Id)
        {
            return View("Index");
        }
        var entity = _context.Urunler.FirstOrDefault(i=>i.Id==model.Id);

        if (entity != null)
        {
            entity.UrunAdi = model.UrunAdi;
            entity.Fiyat = model.UrunFiyat;
            //entity.Resim = "1.jpeg";
            entity.KategoriId = model.KategoriId;
            entity.Anasayfa = model.UrunAnasayfa;
            entity.Aktif = model.UrunAktif;
            entity.Aciklama = model.urunAciklama;
            _context.SaveChanges();

            TempData["Mesaj"] = $"{entity.UrunAdi} urun bilgisi güncellendi";
            return RedirectToAction("Index");            
        }
        return View(model);
    }

}
