using System;
namespace MVC2.Models
{
    public class Laptop
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public Brand Brand { get; set; } = null!;
        public double Price { get; set; }
        public int Year { get; set; }
    }
}

