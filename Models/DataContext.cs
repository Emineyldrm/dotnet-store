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





    //migrations oluşturulduğunda aşağıdaki metot çağrılıyor
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Urun>().HasData(
            new List<Urun>()
            {
                new Urun() { Id = 1, UrunAdi="Apple 7", Fiyat=10000, Aktif=true, Resim="1.jpeg",  Anasayfa=true, Aciklama="Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi totam harum deleniti dolore provident sequi aspernatur possimus eligendi corporis iure repellendus,  quidem accusamus, iusto quia quasi consequatur fuga fugit inventore."},
                new Urun() { Id = 2, UrunAdi="Apple 8", Fiyat=20000, Aktif=false, Resim="2.jpeg",  Anasayfa=false, Aciklama="Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi totam harum deleniti dolore provident sequi aspernatur possimus eligendi corporis iure repellendus,  quidem accusamus, iusto quia quasi consequatur fuga fugit inventore."},
                new Urun() { Id = 3, UrunAdi="Apple 9", Fiyat=30000, Aktif=true, Resim="3.jpeg",  Anasayfa=true, Aciklama="Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi totam harum deleniti dolore provident sequi aspernatur possimus eligendi corporis iure repellendus,  quidem accusamus, iusto quia quasi consequatur fuga fugit inventore."},
                new Urun() { Id = 4, UrunAdi="Apple 10", Fiyat=40000, Aktif=true, Resim="4.jpeg",  Anasayfa=false, Aciklama="Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi totam harum deleniti dolore provident sequi aspernatur possimus eligendi corporis iure repellendus,  quidem accusamus, iusto quia quasi consequatur fuga fugit inventore."},
                new Urun() { Id = 5, UrunAdi="Apple 11", Fiyat=50000, Aktif=false, Resim="5.jpeg",  Anasayfa=true, Aciklama="Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi totam harum deleniti dolore provident sequi aspernatur possimus eligendi corporis iure repellendus,  quidem accusamus, iusto quia quasi consequatur fuga fugit inventore."},
                new Urun() { Id = 6, UrunAdi="Apple 12", Fiyat=60000, Aktif=false, Resim="6.jpeg",  Anasayfa=false, Aciklama="Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi totam harum deleniti dolore provident sequi aspernatur possimus eligendi corporis iure repellendus,  quidem accusamus, iusto quia quasi consequatur fuga fugit inventore."},
                new Urun() { Id = 7, UrunAdi="Apple 13", Fiyat=70000, Aktif=true, Resim="7.jpeg",  Anasayfa=true, Aciklama="Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi totam harum deleniti dolore provident sequi aspernatur possimus eligendi corporis iure repellendus,  quidem accusamus, iusto quia quasi consequatur fuga fugit inventore."},
                new Urun() { Id = 8, UrunAdi="Apple 14", Fiyat=80000, Aktif=true, Resim="8.jpeg",  Anasayfa=true, Aciklama="Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi totam harum deleniti dolore provident sequi aspernatur possimus eligendi corporis iure repellendus,  quidem accusamus, iusto quia quasi consequatur fuga fugit inventore."}, 
            }
        );
    }
}

 


//Connection String
//Migrations

//DataCOntext _context = new DataContext();
