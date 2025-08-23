using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Models;

public class DataContext : DbContext
{
    public DbSet<Urun> Urunler { get; set; }
}

//Connection String
//Migrations
