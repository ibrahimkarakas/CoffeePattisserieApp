using CoffeePattisserieClient.Models;

namespace CoffeePattisserieClient.Repository
{
    public static class DataRepository
    {
        // Categories for the different products
        private static readonly List<CategoryViewModel> _categories = new List<CategoryViewModel>
        {
            new CategoryViewModel() { Id = 1, Name = "Tatlılar" },
            new CategoryViewModel() { Id = 2, Name = "Kahveler" },
            new CategoryViewModel() { Id = 3, Name = "Moctails" },
            new CategoryViewModel() { Id = 4, Name = "Pastalar" }
        };

        // Coffees
        private static readonly List<CoffeeViewModel> _coffees = new List<CoffeeViewModel>
        {
            new CoffeeViewModel()
            {
                Id = 1, 
                Name = "Espresso", 
                OriginCountry = "Italy", 
                RoastLevel = "Dark", 
                FlavorNotes = "Rich and bold", 
                Price = 25, 
                StockQuantity = 50, 
                ImageUrl = "espresso.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 2, Name = "Kahveler" }
                }
            },
            // Other coffee items...
        };

        // Moctails
        private static readonly List<MoctailViewModel> _moctails = new List<MoctailViewModel>
        {
            new MoctailViewModel()
            {
                Id = 1, 
                Name = "Mango Delight", 
                Ingredients = "Mango, Orange, Ice", 
                PreparationMethod = "Shake and serve cold", 
                Price = 40, 
                StockQuantity = 30, 
                ImageUrl = "mango_moctail.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 3, Name = "Moctails" }
                }
            },
            // Other moctail items...
        };

        // Pattisseries
        private static readonly List<PattisserieViewModel> _pattisseries = new List<PattisserieViewModel>
        {
            new PattisserieViewModel()
            {
                Id = 1, 
                Name = "Chocolate Cake", 
                Ingredients = "Chocolate, Flour, Sugar", 
                Allergens = "Gluten, Dairy", 
                ShelfLife = "3 days", 
                Price = 50, 
                StockQuantity = 10, 
                ImageUrl = "chocolate_cake.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 1, Name = "Tatlılar" }
                }
            },
            // Other pattisserie items...
        };

        public static List<CoffeeViewModel> GetCoffees()
        {
            return _coffees;
        }

        public static List<MoctailViewModel> GetMoctails()
        {
            return _moctails;
        }

        public static List<PattisserieViewModel> GetPattisseries()
        {
            return _pattisseries;
        }

        public static List<CategoryViewModel> GetCategories()
        {
            return _categories;
        }

        public static CoffeeViewModel GetCoffee(int id)
        {
            return _coffees.FirstOrDefault(x => x.Id == id);
        }

        public static MoctailViewModel GetMoctail(int id)
        {
            return _moctails.FirstOrDefault(x => x.Id == id);
        }

        public static PattisserieViewModel GetPattisserie(int id)
        {
            return _pattisseries.FirstOrDefault(x => x.Id == id);
        }

        public static CategoryViewModel GetCategory(int id)
        {
            return _categories.FirstOrDefault(x => x.Id == id);
        }
    }
}
