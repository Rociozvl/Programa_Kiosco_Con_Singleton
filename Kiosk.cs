using Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{

    public class Kiosk
    {
        private static Kiosk instance;
        private static readonly object lockObject = new object();
        private List<Product> products;

        private bool isVedaElectoral;

        private Kiosk()
        {
            // Inicializa el kiosco con algunos productos
            products = new List<Product>
        {
            new Product("Gaseosa", 1.5, false, 0, 3),
            new Product("Cerveza", 3.0, true, 18, 5),
            new Product("Caramelos", 0.5, false, 0, 20),
        };

            // Supongamos que no estamos en veda electoral al inicio
            isVedaElectoral = false;
        }

        public static Kiosk Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new Kiosk();
                        }
                    }
                }
                return instance;
            }
        }

        public void DisplayProducts()
        {
            Console.WriteLine("Products available:");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} - Price: ${product.Price} - Alcohol: {product.IsAlcohol} - Age Required: {product.AgeRequired} - Stock: {product.Stock}");
            }
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public void SellProduct(Product product, User user)
        {
            lock (lockObject)
            {
                // Condición de guarda: Verifica que el producto no sea nulo y que esté en stock
                if (product != null && product.Stock > 0)
                {
                    if (product.AgeRequired <= 0 || user.Age >= product.AgeRequired)
                    {
                        Console.WriteLine($"{user.Name} bought: {product.Name} - Price: ${product.Price}");
                        product.Stock--;

                        // Si el stock llega a cero, eliminamos el producto
                        if (product.Stock == 0)
                        {
                            products.Remove(product);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{user.Name} cannot buy {product.Name}. Age requirement not met.");
                    }
                }
                else
                {
                    Console.WriteLine($"Product {product.Name} is out of stock.");
                }
            }
        }
        public bool EnVeda()
        {
            // Supongamos que estamos en veda electoral en el mes de octubre (por ejemplo)
            int currentMonth = DateTime.Now.Month;
            return currentMonth == 10 && isVedaElectoral;

        }
    }
}

                    