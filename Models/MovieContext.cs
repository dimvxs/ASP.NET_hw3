using Microsoft.EntityFrameworkCore;


namespace hw.Models
{
    public class MovieContext: DbContext
    {
        public DbSet<Movie> Movies { get; set;}
        public DbSet<FileModel> Files { get; set;}
        public MovieContext(DbContextOptions<MovieContext> options)
        : base(options)
        {

if(Database.EnsureCreated())
{
Movies?.Add(new Movie 
{
    Name = "Deadpool",
    Director = "Tim Miller",
    Genre = "Action, Comedy",
    Year = 2016,
    Poster = "~/image/deadpool.png",
    Description = "A wisecracking mercenary with accelerated healing powers seeks revenge against the man who experimented on him."
});

Movies?.Add(new Movie 
{
    Name = "Inception",
    Director = "Christopher Nolan",
    Genre = "Sci-Fi, Action",
    Year = 2010,
    Poster = "~/image/Inception.jpeg",
    Description = "A skilled thief, who can enter people's dreams and steal secrets, is tasked with planting an idea into a target's subconscious."
});

Movies?.Add(new Movie 
{
    Name = "The Matrix",
    Director = "Lana Wachowski, Lilly Wachowski",
    Genre = "Sci-Fi, Action",
    Year = 1999,
    Poster = "~/image/TheMatrix.jpeg",
    Description = "A hacker discovers the true nature of reality and joins a rebellion against its controllers."
});

Movies?.Add(new Movie 
{
    Name = "The Dark Knight",
    Director = "Christopher Nolan",
    Genre = "Action, Crime",
    Year = 2008,
    Poster = "~/image/TheDarkknight.jpeg",
    Description = "Batman faces his toughest opponent yet, the Joker, who seeks to create chaos in Gotham."
});

Movies?.Add(new Movie 
{
    Name = "Interstellar",
    Director = "Christopher Nolan",
    Genre = "Sci-Fi, Adventure",
    Year = 2014,
    Poster = "~/image/Interstellar.jpeg",
    Description = "A team of explorers travels through a wormhole in space in search of a new habitable planet."
});

Movies?.Add(new Movie 
{
    Name = "Titanic",
    Director = "James Cameron",
    Genre = "Drama, Romance",
    Year = 1997,
    Poster = "~/image/Titanic.jpeg",
    Description = "A romance unfolds between Jack and Rose aboard the ill-fated Titanic."
});

Movies?.Add(new Movie 
{
    Name = "Gladiator",
    Director = "Ridley Scott",
    Genre = "Action, Drama",
    Year = 2000,
    Poster = "~/image/Gladiator.jpeg",
    Description = "A betrayed Roman general seeks revenge against the corrupt emperor who murdered his family."
});

Movies?.Add(new Movie 
{
    Name = "Pulp Fiction",
    Director = "Quentin Tarantino",
    Genre = "Crime, Drama",
    Year = 1994,
    Poster = "~/image/Pulp_Fiction.jpeg",
    Description = "Interwoven stories of crime, redemption, and dark humor unfold in Los Angeles."
});

Movies?.Add(new Movie 
{
    Name = "The Lord of the Rings: The Fellowship of the Ring",
    Director = "Peter Jackson",
    Genre = "Fantasy, Adventure",
    Year = 2001,
    Poster = "~/image/TheLordoftheRings.jpeg",
    Description = "A young hobbit embarks on a quest to destroy a powerful ring and save Middle-earth."
});

Movies?.Add(new Movie 
{
    Name = "Avengers: Endgame",
    Director = "Anthony Russo, Joe Russo",
    Genre = "Action, Sci-Fi",
    Year = 2019,
    Poster = "~/image/Avengers-Endgame.jpeg",
    Description = "The Avengers assemble for a final showdown against Thanos to restore balance to the universe."
});
SaveChanges();

}
        }
        
    }
}