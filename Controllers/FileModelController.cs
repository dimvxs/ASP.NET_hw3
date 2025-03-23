using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hw.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hw.Controllers
{
    public class FileModelController: Controller
    {

private readonly MovieContext context;

public FileModelController(MovieContext c)
{

context = c;

}

[AcceptVerbs("Get", "Post")]
public async Task<IActionResult> CheckName(string name)
{

bool check = await context.Files.AnyAsync(f => f.Name == name);
return Json(!check);

}
        
    }
}