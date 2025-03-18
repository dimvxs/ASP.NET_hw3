using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using hw.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace hw.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    MovieContext _context;
    IWebHostEnvironment _appEnvironment;

    public HomeController(ILogger<HomeController> logger, MovieContext context, IWebHostEnvironment appEnvironment)
    {
        _logger = logger;
        _context = context; 
        _appEnvironment = appEnvironment;
    }



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

   [HttpPost]
public async Task<IActionResult> AddFile(IFormFile uploadedFile)
{
    if (uploadedFile != null)
    {
        // Получаем путь к wwwroot
        string webRootPath = _appEnvironment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

        // Указываем папку, куда сохранять файлы
        string folderPath = Path.Combine(webRootPath, "files");

        // Создаём папку, если её нет
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Путь к файлу
        string filePath = Path.Combine(folderPath, uploadedFile.FileName);

        // Сохраняем файл
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await uploadedFile.CopyToAsync(fileStream);
        }

        // Сохраняем относительный путь в БД
        FileModel file = new FileModel { Name = uploadedFile.FileName, Path = "/files/" + uploadedFile.FileName };
        _context.Files.Add(file);
        await _context.SaveChangesAsync();
    }

    return RedirectToAction("GetMovies");
}


}
