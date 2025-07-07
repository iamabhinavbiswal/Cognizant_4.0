using Models;
using Microsoft.EntityFrameworkCore;

public class Lab4_InsertData
{
    public static async Task RunAsync()
    {
        Console.WriteLine("\n Lab 4: Insert Initial Data");

        using var context = new AppDbContext();

        if (await context.Categories.AnyAsync())
        {
            Console.WriteLine("Data already exists. Skipping insert.");
            return;
        }

        var electronics = new Category { Name = "Electronics" };
        var groceries = new Category { Name = "Groceries" };

        await context.Categories.AddRangeAsync(electronics, groceries);

        var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
        var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

        await context.Products.AddRangeAsync(product1, product2);

        await context.SaveChangesAsync();

        Console.WriteLine(" Inserted categories and products into database.");
    }
}
