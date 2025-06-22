using System;
using System.Collections.Generic;
using System.Linq;

namespace EcommerceSearch
{
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        public Product(int id, string name, string category)
        {
            ProductId = id;
            ProductName = name;
            Category = category;
        }

        public override string ToString()
        {
            return $"ID: {ProductId}, Name: {ProductName}, Category: {Category}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("E-commerce Platform Search System");

            List<Product> products = new List<Product>
            {
                new Product(101, "Laptop", "Electronics"),
                new Product(102, "Phone", "Electronics"),
                new Product(103, "Shoes", "Apparel"),
                new Product(104, "Book", "Stationery"),
                new Product(105, "Watch", "Accessories"),
                new Product(106, "Tablet", "Electronics")
            };

            Console.Write("\nEnter product name to search: ");
            string searchTerm = Console.ReadLine();

            Console.Write("Choose search type (1 for Linear, 2 for Binary): ");
            int choice = int.Parse(Console.ReadLine());

            Product result = null;

            if (choice == 1)
            {
                Console.WriteLine("\n Performing Linear Search...");
                result = LinearSearch(products.ToArray(), searchTerm);
            }
            else if (choice == 2)
            {
                Console.WriteLine("\n Performing Binary Search (on sorted product names)...");
                var sorted = products.OrderBy(p => p.ProductName).ToArray();
                result = BinarySearch(sorted, searchTerm);
            }
            else
            {
                Console.WriteLine(" Invalid choice.");
                return;
            }

            if (result != null)
                Console.WriteLine($"\n Product Found: {result}");
            else
                Console.WriteLine("\n Product Not Found");

            Console.WriteLine("\n Time Complexity Analysis:");
            Console.WriteLine("\n1. Linear Search:");
            Console.WriteLine("   Best Case  O(1)");
            Console.WriteLine("   Average Case  O(n)");
            Console.WriteLine("   Worst Case  O(n)");

            Console.WriteLine("\n2. Binary Search (sorted array):");
            Console.WriteLine("   Best Case    O(1)");
            Console.WriteLine("   Average Case O(log n)");
            Console.WriteLine("   Worst Case   O(log n)");
        }

        static Product LinearSearch(Product[] products, string productName)
        {
            foreach (var p in products)
            {
                if (p.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase))
                    return p;
            }
            return null;
        }

        static Product BinarySearch(Product[] sortedProducts, string productName)
        {
            int left = 0;
            int right = sortedProducts.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comp = string.Compare(sortedProducts[mid].ProductName, productName, true);

                if (comp == 0)
                    return sortedProducts[mid];
                else if (comp < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return null;
        }
    }
}
