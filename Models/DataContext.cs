using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Models;

public class DataContext : DbContext
{
    //Yapıcı metotlar(Constructor methods)
    //ctor TAB
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<Urun> Urunler { get; set; }
    public DbSet<Kategori> Kategoriler { get; set; }
    public DbSet<Slider> Sliderlar { get; set; }





    //migrations oluşturulduğunda aşağıdaki metot çağrılıyor
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Slider>().HasData(
            new List<Slider>()
            {
                new Slider() { Id=1, Baslik="Slider 1 Baslik", Aciklama="Slider 1 Aciklama",  Resim="slider-1.jpeg", Index=0, Aktif=true},
                new Slider() { Id=2, Baslik="Slider 2 Baslik", Aciklama="Slider 2 Aciklama",  Resim="slider-2.jpeg", Index=1, Aktif=true},
                new Slider() { Id=3, Baslik="Slider 3 Baslik", Aciklama="Slider 3 Aciklama",  Resim="slider-3.jpeg", Index=2, Aktif=true}
            }
        );

        modelBuilder.Entity<Kategori>().HasData(
            new List<Kategori>()
            {
                new Kategori(){Id=1, KategoriAdi="Telefon", Url="telefon"},
                new Kategori(){Id=2, KategoriAdi="Beyaz Eşya", Url="beyaz-esya"},
                new Kategori(){Id=3, KategoriAdi="Elektronik", Url="elektronik"},
                new Kategori(){Id=4, KategoriAdi="Kozmetik", Url="kozmetik"},
                new Kategori(){Id=5, KategoriAdi="Giyim", Url="giyim"},
                new Kategori(){Id=6, KategoriAdi="Kategori 1", Url="kategori-1"},
                new Kategori(){Id=7, KategoriAdi="Kategori 2", Url="kategori-2"},
                new Kategori(){Id=8, KategoriAdi="Kategori 3", Url="kategori-3"},
                new Kategori(){Id=9, KategoriAdi="Kategori 4", Url="kategori-4"},
                new Kategori(){Id=10, KategoriAdi="Kategori 5", Url="kategori-5"},
                new Kategori(){Id=11, KategoriAdi="Kategori 6", Url="kategori-6"},

            }
        );

        modelBuilder.Entity<Urun>().HasData(
            new List<Urun>()
            {
                new Urun() { Id = 1, UrunAdi="Apple 7", Fiyat=10000, Aktif=true, Resim="1.jpeg",  Anasayfa=true, Aciklama="Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi totam harum deleniti dolore provident sequi aspernatur possimus eligendi corporis iure repellendus,  quidem accusamus, iusto quia quasi consequatur fuga fugit inventore.",KategoriId=1},
                new Urun() { Id = 2, UrunAdi="Apple 8", Fiyat=20000, Aktif=false, Resim="2.jpeg",  Anasayfa=false, Aciklama="Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi totam harum deleniti dolore provident sequi aspernatur possimus eligendi corporis iure repellendus,  quidem accusamus, iusto quia quasi consequatur fuga fugit inventore.",KategoriId=1},
                new Urun() { Id = 3, UrunAdi="Apple 9", Fiyat=30000, Aktif=true, Resim="3.jpeg",  Anasayfa=true, Aciklama="Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi totam harum deleniti dolore provident sequi aspernatur possimus eligendi corporis iure repellendus,  quidem accusamus, iusto quia quasi consequatur fuga fugit inventore.",KategoriId=3},
                new Urun() { Id = 4, UrunAdi="Apple 10", Fiyat=40000, Aktif=true, Resim="4.jpeg",  Anasayfa=false, Aciklama="Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi totam harum deleniti dolore provident sequi aspernatur possimus eligendi corporis iure repellendus,  quidem accusamus, iusto quia quasi consequatur fuga fugit inventore.",KategoriId=1},
                new Urun() { Id = 5, UrunAdi="Apple 11", Fiyat=50000, Aktif=false, Resim="5.jpeg",  Anasayfa=true, Aciklama="Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi totam harum deleniti dolore provident sequi aspernatur possimus eligendi corporis iure repellendus,  quidem accusamus, iusto quia quasi consequatur fuga fugit inventore.",KategoriId=1},
                new Urun() { Id = 6, UrunAdi="Apple 12", Fiyat=60000, Aktif=false, Resim="6.jpeg",  Anasayfa=false, Aciklama="Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi totam harum deleniti dolore provident sequi aspernatur possimus eligendi corporis iure repellendus,  quidem accusamus, iusto quia quasi consequatur fuga fugit inventore.",KategoriId=1},
                new Urun() { Id = 7, UrunAdi="Apple 13", Fiyat=70000, Aktif=true, Resim="7.jpeg",  Anasayfa=true, Aciklama="Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi totam harum deleniti dolore provident sequi aspernatur possimus eligendi corporis iure repellendus,  quidem accusamus, iusto quia quasi consequatur fuga fugit inventore.",KategoriId=1},
                new Urun() { Id = 8, UrunAdi="Apple 14", Fiyat=80000, Aktif=true, Resim="8.jpeg",  Anasayfa=true, Aciklama="Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi totam harum deleniti dolore provident sequi aspernatur possimus eligendi corporis iure repellendus,  quidem accusamus, iusto quia quasi consequatur fuga fugit inventore.",KategoriId=1},
            }
        );
    }
}

 


//Connection String
//Migrations

//DataCOntext _context = new DataContext();
