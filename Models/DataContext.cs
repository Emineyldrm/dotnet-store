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
                new Urun() { Id = 1, UrunAdı="Apple 7", Fiyat=10000, Aktif=true},
                new Urun() { Id = 2, UrunAdı="Apple 8", Fiyat=20000, Aktif=false},
                new Urun() { Id = 3, UrunAdı="Apple 9", Fiyat=30000, Aktif=true},
                new Urun() { Id = 4, UrunAdı="Apple 10", Fiyat=40000, Aktif=true},
                new Urun() { Id = 5, UrunAdı="Apple 11", Fiyat=50000, Aktif=false}, 
                new Urun() { Id = 6, UrunAdı="Apple 12", Fiyat=60000, Aktif=true}, 
            }
        );
    }
}

 


//Connection String
//Migrations

//DataCOntext _context = new DataContext();
