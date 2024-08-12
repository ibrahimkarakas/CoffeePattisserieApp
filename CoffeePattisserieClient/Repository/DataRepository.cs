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
            new CoffeeViewModel()
            {
                Id = 2, 
                Name = "Americano", 
                OriginCountry = "USA", 
                RoastLevel = "Medium", 
                FlavorNotes = "Smooth and balanced", 
                Price = 20, 
                StockQuantity = 60, 
                ImageUrl = "americano.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 2, Name = "Kahveler" }
                }
            },
            new CoffeeViewModel()
            {
                Id = 3, 
                Name = "Latte", 
                OriginCountry = "Italy", 
                RoastLevel = "Light", 
                FlavorNotes = "Creamy and smooth", 
                Price = 30, 
                StockQuantity = 40, 
                ImageUrl = "latte.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 2, Name = "Kahveler" }
                }
            },
            new CoffeeViewModel()
            {
                Id = 4, 
                Name = "Cappuccino", 
                OriginCountry = "Italy", 
                RoastLevel = "Medium", 
                FlavorNotes = "Rich and frothy", 
                Price = 28, 
                StockQuantity = 45, 
                ImageUrl = "cappuccino.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 2, Name = "Kahveler" }
                }
            },
            new CoffeeViewModel()
            {
                Id = 5, 
                Name = "Mocha", 
                OriginCountry = "Yemen", 
                RoastLevel = "Dark", 
                FlavorNotes = "Chocolatey and rich", 
                Price = 35, 
                StockQuantity = 35, 
                ImageUrl = "mocha.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 2, Name = "Kahveler" }
                }
            },
            new CoffeeViewModel()
            {
                Id = 6, 
                Name = "Flat White", 
                OriginCountry = "Australia", 
                RoastLevel = "Medium", 
                FlavorNotes = "Smooth and velvety", 
                Price = 30, 
                StockQuantity = 30, 
                ImageUrl = "flat_white.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 2, Name = "Kahveler" }
                }
            },
            new CoffeeViewModel()
            {
                Id = 7, 
                Name = "Cold Brew", 
                OriginCountry = "USA", 
                RoastLevel = "Light", 
                FlavorNotes = "Cool and refreshing", 
                Price = 25, 
                StockQuantity = 25, 
                ImageUrl = "cold_brew.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 2, Name = "Kahveler" }
                }
            }
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
            new MoctailViewModel()
            {
                Id = 2, 
                Name = "Berry Blast", 
                Ingredients = "Blueberries, Raspberries, Ice", 
                PreparationMethod = "Blend and serve cold", 
                Price = 45, 
                StockQuantity = 25, 
                ImageUrl = "berry_blast.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 3, Name = "Moctails" }
                }
            },
            new MoctailViewModel()
            {
                Id = 3, 
                Name = "Citrus Cooler", 
                Ingredients = "Lemon, Lime, Ice", 
                PreparationMethod = "Mix and serve with ice", 
                Price = 35, 
                StockQuantity = 20, 
                ImageUrl = "citrus_cooler.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 3, Name = "Moctails" }
                }
            },
            new MoctailViewModel()
            {
                Id = 4, 
                Name = "Pineapple Punch", 
                Ingredients = "Pineapple, Coconut Water, Ice", 
                PreparationMethod = "Blend and serve cold", 
                Price = 50, 
                StockQuantity = 15, 
                ImageUrl = "pineapple_punch.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 3, Name = "Moctails" }
                }
            },
            new MoctailViewModel()
            {
                Id = 5, 
                Name = "Tropical Paradise", 
                Ingredients = "Passionfruit, Pineapple, Ice", 
                PreparationMethod = "Shake and serve cold", 
                Price = 45, 
                StockQuantity = 20, 
                ImageUrl = "tropical_paradise.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 3, Name = "Moctails" }
                }
            },
            new MoctailViewModel()
            {
                Id = 6, 
                Name = "Virgin Mojito", 
                Ingredients = "Mint, Lime, Soda", 
                PreparationMethod = "Mix and serve with ice", 
                Price = 30, 
                StockQuantity = 40, 
                ImageUrl = "virgin_mojito.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 3, Name = "Moctails" }
                }
            },
            new MoctailViewModel()
            {
                Id = 7, 
                Name = "Apple Fizz", 
                Ingredients = "Apple, Ginger Ale, Ice", 
                PreparationMethod = "Mix and serve with ice", 
                Price = 35, 
                StockQuantity = 35, 
                ImageUrl = "apple_fizz.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 3, Name = "Moctails" }
                }
            },
            new MoctailViewModel()
            {
                Id = 8, 
                Name = "Grapefruit Spritz", 
                Ingredients = "Grapefruit, Soda, Ice", 
                PreparationMethod = "Shake and serve cold", 
                Price = 38, 
                StockQuantity = 25, 
                ImageUrl = "grapefruit_spritz.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 3, Name = "Moctails" }
                }
            },
            new MoctailViewModel()
            {
                Id = 9, 
                Name = "Cucumber Mint", 
                Ingredients = "Cucumber, Mint, Soda", 
                PreparationMethod = "Mix and serve with ice", 
                Price = 32, 
                StockQuantity = 30, 
                ImageUrl = "cucumber_mint.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 3, Name = "Moctails" }
                }
            },
            new MoctailViewModel()
            {
                Id = 10, 
                Name = "Peach Iced Tea", 
                Ingredients = "Peach, Tea, Ice", 
                PreparationMethod = "Mix and serve with ice", 
                Price = 30, 
                StockQuantity = 35, 
                ImageUrl = "peach_iced_tea.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 3, Name = "Moctails" }
                }
            }
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
            new PattisserieViewModel()
            {
                Id = 2, 
                Name = "Cheesecake", 
                Ingredients = "Cream Cheese, Sugar, Graham Cracker Crust", 
                Allergens = "Gluten, Dairy", 
                ShelfLife = "5 days", 
                Price = 60, 
                StockQuantity = 15, 
                ImageUrl = "cheesecake.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 1, Name = "Tatlılar" }
                }
            },
            new PattisserieViewModel()
            {
                Id = 3, 
                Name = "Tiramisu", 
                Ingredients = "Coffee, Mascarpone, Ladyfingers", 
                Allergens = "Gluten, Dairy", 
                ShelfLife = "4 days", 
                Price = 55, 
                StockQuantity = 12, 
                ImageUrl = "tiramisu.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 1, Name = "Tatlılar" }
                }
            },
            new PattisserieViewModel()
            {
                Id = 4, 
                Name = "Lemon Tart", 
                Ingredients = "Lemon, Sugar, Flour", 
                Allergens = "Gluten, Dairy", 
                ShelfLife = "3 days", 
                Price = 45, 
                StockQuantity = 20, 
                ImageUrl = "lemon_tart.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 1, Name = "Tatlılar" }
                }
            },
            new PattisserieViewModel()
            {
                Id = 5, 
                Name = "Éclair", 
                Ingredients = "Choux Pastry, Cream, Chocolate", 
                Allergens = "Gluten, Dairy", 
                ShelfLife = "2 days", 
                Price = 35, 
                StockQuantity = 25, 
                ImageUrl = "eclair.png", 
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id = 1, Name = "Tatlılar" }
                }
            }
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
