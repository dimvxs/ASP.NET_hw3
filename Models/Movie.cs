using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace hw.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите название фильма")]
        [Remote(action: "CheckName", controller: "Movies", ErrorMessage = "Фильм с таким названием уже есть")]
        [Display(Name = "Название фильма")]
        
        public string? Name { get; set; }

        [Required(ErrorMessage = "Укажите режиссера фильма")]
        [Display(Name = "Режиссер фильма")]
        public string? Director { get; set; }

        [Required(ErrorMessage = "Укажите жанр фильма")]
        [Display(Name = "Жанр фильма")]
        public string? Genre { get; set; }

        [Required(ErrorMessage = "Укажите год выпуска фильма")]
        [Display(Name = "Год фильма")]
        [Range(1800, 2035, ErrorMessage = "Недопустимый год")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Укажите постер фильма")]
        [Display(Name = "Постер фильма")]
        public string? Poster { get; set; }

        [Required(ErrorMessage = "Укажите описание фильма")]
        [Display(Name = "Описание фильма")]
        public string? Description { get; set; }

        public Movie(){}
    }
}