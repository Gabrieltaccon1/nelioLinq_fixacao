using System;
using System.Collections.Generic;
using EXEMPLO_LINQ2.Entities;
using System.Linq;


namespace EXEMPLO_LINQ2
{
    class Program
    {
        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
               
            }
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Electronics", Tier = 1 };


            List<Product> products = new List<Product>()
            {
                new Product() {Id =1, Name= "Computer", Price = 1100.0, Category = c2},
            new Product() { Id = 2, Name = "Hammer", Price = 90.0, Category = c1 },
            new Product() { Id = 3, Name = "TV", Price = 1700.0, Category = c3},
            new Product() {Id =4, Name= "NOTEBOOK", Price = 1300.0, Category = c2},
            new Product() {Id =5, Name= "SAW", Price = 80.0, Category = c1},
            new Product() {Id =6, Name= "TABLET", Price = 700.0, Category = c2},
            new Product() {Id =7, Name= "CAMERA", Price = 700.0, Category = c3},
            new Product() {Id =8, Name= "PRINTER", Price = 350.0, Category = c3},
            new Product() {Id =9, Name= "MACBOOK", Price = 1800.0, Category = c2},
            new Product() {Id =10, Name= "SOUND BAR", Price = 700.0, Category = c3},
            new Product() {Id =11, Name= "LEVEL", Price = 70.0, Category = c1}
            };

            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.00);
            Print("TIER 1 AND PRICE <900" , r1 );


            var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
            Print("NAMES OF PRODUCTS FROM TOOLS", r2);

            var r3 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
            Print("NAMES STARTED WITH 'c' AND ANONYMOUS OBJECT", r3);

            var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME  ", r4);

            var r5 = r4.Skip(2).Take(4); // pule 2  e pegue 4
            Print("TIER 1 ORDER BY PRICE THEN BY NAME SKIP 2 TAKE 4 ", r5);

            var r6 = products.FirstOrDefault();
            Console.WriteLine("FISRT or Default TEST1" + r6);

            var r7 = products.Where(p => p.Price > 3000.0).FirstOrDefault();
            Console.WriteLine("FIRST or Default TEST2"+ r7);
            Console.WriteLine("");

            var r8 = products.Where(p => p.Id == 3).SingleOrDefault();
            Console.WriteLine("SINGLE OR DEFAULT TEST1:" + r8);

            var r9 = products.Where(p => p.Id == 30).SingleOrDefault();
            Console.WriteLine("SINGLE OR DEFAULT TEST2:" + r9);
            Console.WriteLine("");

            // pega o maximo da minha coleção
            var r10 = products.Max(p => p.Price);
            // pode ser chamado sem parametros ou pode conter uma expressão lambda
            Console.WriteLine("Max price: " + r10);

            var r11 = products.Min(p => p.Price);
            Console.WriteLine("Min price: " + r11);


            // soma dos produtos que levam a categoria 1 
            var r12 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price);
            Console.WriteLine("Category 1 Sum Prices: "+ r12);

            // Media
            var r13 = products.Where(p => p.Category.Id == 1).Average(p => p.Price);
            Console.WriteLine("Category 1 Average Prices: " + r13);


            // evitar exeção de erro na media
            var r14 = products.Where(p => p.Category.Id == 5).Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("Category 5 Average Prices: " + r14);

            //montar uma operação agregada personalizada VV (minha propia operção)
                                                                                            // 0.0 trata erro                
            var r15 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate(0.0,(x, y) => x + y);
            Console.WriteLine("CATEGORY 1 AGGREGATE SUM: " + r15);


            // operação de agrupamento

            //var r16 = products.GroupBy(p => p.Category);
            //foreach (IGrouping<Category, Product> group in r16)
            //{
            //    Console.WriteLine("CATEGORY" + group.Key.Name + ":");
            //    foreach (Product p in group)
            //    {
            //        Console.WriteLine(p);
            //    }
            //    Console.WriteLine("");
            //}
           


        }
    }
}

