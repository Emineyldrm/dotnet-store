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
}

//Connection String
//Migrations

//DataCOntext _context = new DataContext();
