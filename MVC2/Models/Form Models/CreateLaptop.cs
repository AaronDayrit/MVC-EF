﻿using System;
namespace MVC2.Models
{
	public class CreateLaptop
	{
        public string ModelName { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public int Year { get; set; }

		public Laptop Result { get; set; }
	}
}


