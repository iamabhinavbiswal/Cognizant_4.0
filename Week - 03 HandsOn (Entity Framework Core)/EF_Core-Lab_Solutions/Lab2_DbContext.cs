public class Lab2_DbContext
{
    public static void Run()
    {
        Console.WriteLine("\n Lab 2: Setup DbContext");

        using var context = new AppDbContext();

        Console.WriteLine("DbContext configured with SQL Server.");
        Console.WriteLine($"Model: Product → Table: Products");
        Console.WriteLine($"Model: Category → Table: Categories");
    }
}
