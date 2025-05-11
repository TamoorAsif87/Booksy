using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data;

public class StoreDataSeed
{
    public async static Task SeedDataAsync(ApplicationDbContext context)
    {
        if(context.Categories.Count() == 0)
        {
            var data = await File.ReadAllTextAsync("../../infrastructure//Infrastructure/Data/SeedData/categories.json");

            var categories = JsonSerializer.Deserialize<List<Category>>(data);

            await context.Categories.AddRangeAsync(categories!);
            await context.SaveChangesAsync();
        }

        if (context.Books.Count() == 0)
        {
            var data = await File.ReadAllTextAsync("../../infrastructure/Infrastructure/Data/SeedData/books.json");

            var books = JsonSerializer.Deserialize<List<Book>>(data);

            await context.Books.AddRangeAsync(books!);
            await context.SaveChangesAsync();
        }
    }
}
