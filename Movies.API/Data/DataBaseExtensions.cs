using Microsoft.EntityFrameworkCore;

namespace Movies.API.Data;

public static class DataBaseExtensions
{
    public async static Task InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<MoviesApiContext>();

        context.Database.MigrateAsync().GetAwaiter().GetResult();

        await SeedAsync(context);

    }

    private static async Task SeedAsync(MoviesApiContext context)
    {
        await SeedMoviesAsync(context);
        // await SeedOtherData();
    }

    private static async Task SeedMoviesAsync(MoviesApiContext context)
    {
        if (await context.Movies.AnyAsync()) return;

        await context.Movies.AddRangeAsync(InitialData.MoviesInitialData);
        await context.SaveChangesAsync();
    }
}