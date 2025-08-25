using Microsoft.AspNetCore.Mvc;
using dotnet_store.Models;

namespace dotnet_store.ViewComponents;

public class Slider : ViewComponent
{
    private readonly DataContext _context;

    public Slider(DataContext context)
    {
        _context = context;
    }
    public IViewComponentResult Invoke()
    {
        return View(_context.Sliderlar.ToList());
    }
}