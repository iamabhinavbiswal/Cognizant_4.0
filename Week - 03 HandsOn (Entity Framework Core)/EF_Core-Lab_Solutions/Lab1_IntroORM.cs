using Models;

public class Lab1_IntroORM
{
    public static void Run()
    {
        Console.WriteLine(" Lab 1: Understand ORM");

        var electronics = new Category
        {
            Name = "Electronics",
            Products = new List<Product>()
        };

        var laptop = new Product
        {
            Name = "Laptop",
            Price = 75000,
            Category = electronics
        };

        electronics.Products.Add(laptop);

        Console.WriteLine($"Product: {laptop.Name}, Category: {laptop.Category.Name}");
    }
}
