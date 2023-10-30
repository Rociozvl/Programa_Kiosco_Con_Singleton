using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
   public class Product
    {
        public string Name {  get; set; }
        public double Price { get; set; }   

        public bool IsAlcohol { get; set; }

       public int AgeRequired { get; set; }   

        public int Stock {  get; set; } 
        public Product( string name , double price , bool isAlcohol , int ageRequired , int stock) 
        {
            Name = name;
            Price = price;
            IsAlcohol = isAlcohol;
            AgeRequired = ageRequired;
            Stock = stock;
          
        
        
        }
    }
}
