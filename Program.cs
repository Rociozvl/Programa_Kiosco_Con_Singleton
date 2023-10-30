
using Singleton;
using System;
using System.Threading;


    public class Program
    {
    public static void Main()
    {
        Kiosk kiosk = Kiosk.Instance;

        User user1 = new User("Alice", 20);
        User user2 = new User("Bob", 18);

        // Muestra los productos disponibles en el kiosco
        kiosk.DisplayProducts();

        // Obtiene la lista de productos y vende productos a los usuarios desde múltiples hilos
        List<Product> productList = kiosk.GetProducts();
        Thread[] threads = new Thread[5];

        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(() =>
            {
                Product productToSell = productList.FirstOrDefault(p => !p.IsAlcohol && p.AgeRequired <= 0);
                kiosk.SellProduct(productToSell, user1);
            });



        }
            // Inicia todos los hilos al mismo tiempo
            foreach (var thread in threads)
            {
                thread.Start();
            }

            // Espera a que todos los hilos terminen
            foreach (var thread in threads)
            {
                thread.Join();
            }
        


        //Thread thread1 = new Thread(() =>
        //{
        //    Product productToSell = productList.FirstOrDefault(p => !p.IsAlcohol && p.AgeRequired <= 0);
        //    kiosk.SellProduct(productToSell, user1);
        //});

        //Thread thread2 = new Thread(() =>
        //{
        //    if (kiosk.EnVeda())
        //    {
        //        Console.WriteLine("Cannot sell alcohol during electoral ban.");


        //    }
        //    else
        //    {
        //        Product productToSell = productList.FirstOrDefault(p => p.IsAlcohol);
        //        kiosk.SellProduct(productToSell, user2);
        //    }

        //});

        //thread1.Start();
        //thread2.Start();

        //thread1.Join();
        //thread2.Join();

        // Muestra los productos restantes en el kiosco
        kiosk.DisplayProducts();
    }
}