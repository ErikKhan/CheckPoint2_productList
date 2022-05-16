using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckPoint2_productList
{
    internal class Program
    {

        //Method to exit 
        static bool exit(string x)
        {
            if (x.ToLower().Trim() == "q")
            {
                return true;
            }
            return false;
        }

        // Method to print the List
        static void print(List<Product> products)
        {
            // Prices from low to high and sum at the bottom
            List<Product> sortedPrices = products.OrderByDescending(product => product.Price).ToList();
            Console.WriteLine("\t------------------------");
            Console.WriteLine("\tCATEGORY |".PadRight(10) + "NAME |".PadRight(10) + "PRICE");
            Console.WriteLine("\t------------------------");
            foreach (var product in sortedPrices)
            {
                //Console.WriteLine("\t------------------------");
                Console.WriteLine($"\t{product.Category.PadRight(10)}|{product.Name.PadRight(10)}|{product.Price}");
                //Console.WriteLine("\t"+product.Category.PadRight(10)+product.Name.PadRight(10)+product.Price);
            }
            Console.WriteLine("\t------------------------");
            // Sum Of all the prices that the User has inputted
            int sumPrices = products.Sum(product => product.Price);
            Console.WriteLine($"\tThe Sum of the prices|{sumPrices}");


            //Refactoring your code using "Linq".
            Console.WriteLine("\t------------------------");
            Console.WriteLine("");
            Console.WriteLine("My Products - FILTERED by PRICE between 100-9000");
            Console.WriteLine("\t------------------------");
            List<Product> priceBetween = products.Where(product => product.Price >= 100 && product.Price <= 9000).ToList();
            Console.WriteLine("\tCategory |".PadRight(10) + "Name |".PadRight(10) + "Price");
            foreach (var product in priceBetween)
            {
                Console.WriteLine($"\t{product.Category.PadRight(10)}|{product.Name.PadRight(10)}|{product.Price}");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("----------This is a Product List-----------\n");
            Console.WriteLine("\t Type 'q' to quit \n");


            List<Product> products = new List<Product>();
            //While Loop to get user Input

            while (true)
            {

            addmore: Product product1 = new Product();

                Console.Write("\tEnter the Product Category: ");
                string valueCategory = Console.ReadLine();
                if (exit(valueCategory))
                {
                    print(products);
                    Console.Write("If you want to add more Products press Y ");
                    string outProgramm = Console.ReadLine();
                    if (outProgramm.ToLower().Trim() == "y")
                        goto addmore;
                    else
                        break;
                }


                else
                {
                    Console.Write("\tEnter the Product Name: ");
                    string valueName = Console.ReadLine();
                enterPriceAgain: Console.Write("\tEnter the Product Price: ");
                    int valuePrice = int.Parse(Console.ReadLine());

                    //Showing the error if the price is not between 10 to 6500.

                    if ((valuePrice < 10 || valuePrice > 6500))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The Price must be between 10 and 6500 !!");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto enterPriceAgain;
                    }
                    Console.WriteLine("");


                    product1.Category = valueCategory;
                    product1.Name = valueName;
                    product1.Price = valuePrice;
                    // Adding all the products in the List
                    products.Add(product1);


                }
            }
        }
    }

    public class Product
    {
        public Product()
        {
        }

        public Product(string category, string name, int price)
        {
            Category = category;
            Name = name;
            Price = price;
        }

        public string Category { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public int Sum(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
