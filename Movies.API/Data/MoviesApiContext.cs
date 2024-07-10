using Microsoft.EntityFrameworkCore;
using Movies.API.Model;

namespace Movies.API.Data;

public sealed class MoviesApiContext(DbContextOptions<MoviesApiContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies => Set<Movie>();

}