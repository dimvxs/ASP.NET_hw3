using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace hw.Models
{
    public class FileModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите название файла")]
        [Remote(action: "CheckName", controller: "FileModel", ErrorMessage = "файл с таким именем уже существует")]
        [Display(Name = "Название файла")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите путь к файлу")]
        [Display(Name = "Путь к файлу")]
        public string Path { get; set; }

        public FileModel(){}

    }
}