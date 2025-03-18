using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using hw.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hw.Controllers
{
    public class MoviesController: Controller
    {
       private readonly MovieContext context;
       IWebHostEnvironment appEnvironment;
        public MoviesController(MovieContext _context, IWebHostEnvironment _appEnvironment)
        {
            context = _context;
            appEnvironment = _appEnvironment;
        }

        public async Task<IActionResult> GetMovies()
        {
            // IEnumerable<Movie> movies = await context.Movies.ToListAsync(); 
            // ViewBag.Movies = movies;
            // return View();
                 return View(await context.Movies.ToListAsync());
        }

        public async Task<IActionResult> AddFile(int? id){
              if(id == null){
                return NotFound();
            }
            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if(movie == null){
                return NotFound();
            }
            return View(movie);
        }

[HttpPost]
public async Task<IActionResult> AddFile(IFormFile uploadedFile, int id){
  
    
    if(uploadedFile != null)
    {
        // Получаем путь к wwwroot
        string webRootPath = appEnvironment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
      
        // Указываем папку, куда сохранять файлы
        string folderPath = Path.Combine(webRootPath, "files");

        if(!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string filePath = Path.Combine(folderPath, uploadedFile.FileName);

        using(var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await uploadedFile.CopyToAsync(fileStream);
        }

        var movie = await context.Movies.FindAsync(id);
        
        if(movie != null){
        FileModel file = new FileModel { Name = uploadedFile.FileName, Path = "/files/" + uploadedFile.FileName };
        context.Files.Add(file);  
        movie.Poster = file.Path;
        context.Update(movie);
        await context.SaveChangesAsync();
        }
        else{
            return NotFound();
        }
        
    

    }
    return RedirectToAction(nameof(GetMovies));
}



        public async Task<IActionResult> Details(int? id){
            if(id == null){
                return NotFound();
            }
            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if(movie == null){
                return NotFound();
            }
            return View(movie);
        }

        public IActionResult Create(){
            return View();
        }

[HttpPost]
[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, Director, Genre, Year, Poster, Description")] Movie movie)
        {
            if(ModelState.IsValid)
            {
                context.Add(movie);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(GetMovies));
            }
            return View(movie);
        }


        public async Task<IActionResult> Edit(int? id){
            if(id == null){
                return NotFound();
            }
            var movie = await context.Movies.FindAsync(id);
            if(movie == null){
                return NotFound();
            }
            return View(movie);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Director, Genre, Year, Poster, Description")] Movie movie) {
if(ModelState.IsValid){
    try{
    context.Update(movie);
    await context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(GetMovies));
}
      return View(movie);

        }


        public async Task<IActionResult> Delete(int? id){
            if(id == null){
                return NotFound();
            }
            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if(movie == null){
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id){
           var movie = await context.Movies.FindAsync(id);
           if(movie != null){
            context.Movies.Remove(movie);
           }
           await context.SaveChangesAsync();
           return RedirectToAction(nameof(GetMovies));
        }

        private bool MovieExists(int id){
            return context.Movies.Any(m => m.Id == id);
        }
      

    }
}