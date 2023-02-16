using System;
namespace MVC2.Models
{
	public class CreateLaptopViewModel
	{
        public readonly LaptopBrandsContext Context;
        public Laptop Result { get; set; }

        public CreateLaptopViewModel(Laptop result)
        {
            Result = result;
        }

    }
}

