using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using static NUnit.Framework.Internal.OSPlatform;

namespace Data
{
    public class GameShopContext : DbContext
    {
        public DbSet<TypeProduct> TypeProducts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public GameShopContext() : base("name=GameShopContext")
        {
        }
        public GameShopContext(System.Data.Common.DbConnection connectionString) : base(connectionString,true)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>().HasKey(x => new { x.OrderId, x.ProductId });
            base.OnModelCreating(modelBuilder);
        }

        public void SeedDatabase()
        {
            if (!Users.Any() && !Products.Any() && !Orders.Any())
            {
                // === USERS ===
                var users = new List<User>
                {
                    new User { UserName = "admin1", Password = "admin123", Email = "admin1@gameShop.bg", IsAdmin = true },
                    new User { UserName = "admin2", Password = "admin123", Email = "admin2@gameShop.bg", IsAdmin = true },
                    new User { UserName = "ivan.petrov", Password = "passIvan01", Email = "ivan.petrov@gmail.com", IsAdmin = false },
                    new User { UserName = "maria.georgieva", Password = "maria2023", Email = "maria.g@gmail.com", IsAdmin = false },
                    new User { UserName = "pesho92", Password = "peshoRocks", Email = "pesho92@abv.bg", IsAdmin = false },
                    new User { UserName = "IvanTheGreat", Password = "pass123", Email = "ivan@gmail.com", IsAdmin = true },
                    new User { UserName = "Gosho", Password = "goshko123", Email = "gosho@gmail.com", IsAdmin = false },
                    new User { UserName = "PeshoPlays", Password = "pesho123", Email = "pesho@gmail.com", IsAdmin = false },
                    new User { UserName = "NikiNinja", Password = "ninja999", Email = "niki@gmail.com", IsAdmin = false },
                    new User { UserName = "VikiVision", Password = "viki456", Email = "viki@gmail.com", IsAdmin = false },
                    new User { UserName = "ToniTornado", Password = "wind123", Email = "toni@gmail.com", IsAdmin = false },
                    new User { UserName = "SlaviSlams", Password = "boom321", Email = "slavi@gmail.com", IsAdmin = false },
                    new User { UserName = "MimiMagic", Password = "abracadabra", Email = "mimi@gmail.com", IsAdmin = false },
                    new User { UserName = "KamenKiller", Password = "stonepass", Email = "kamen@gmail.com", IsAdmin = false },
                    new User { UserName = "DaniDino", Password = "roar321", Email = "dani@gmail.com", IsAdmin = false },
                    new User { UserName = "MitkoMaster", Password = "mitko123", Email = "mitko@gmail.com", IsAdmin = false },
                    new User { UserName = "RadoRage", Password = "angrypass", Email = "rado@gmail.com", IsAdmin = false },
                    new User { UserName = "LuboLogic", Password = "brainy987", Email = "lubo@gmail.com", IsAdmin = false },
                    new User { UserName = "AniArrow", Password = "bowbow", Email = "ani@gmail.com", IsAdmin = false },
                    new User { UserName = "ZoriZoom", Password = "speed77", Email = "zori@gmail.com", IsAdmin = false },
                    new User { UserName = "PlamiPunch", Password = "fightme", Email = "plami@gmail.com", IsAdmin = false },
                    new User { UserName = "EmoEpic", Password = "epicgame", Email = "emo@gmail.com", IsAdmin = false },
                    new User { UserName = "IvaIce", Password = "freeze", Email = "iva@gmail.com", IsAdmin = false },
                    new User { UserName = "StefiStorm", Password = "stormy", Email = "stefi@gmail.com", IsAdmin = false },
                    new User { UserName = "TediTiger", Password = "meowmeow", Email = "tedi@gmail.com", IsAdmin = false },
                    new User { UserName = "YaniYoda", Password = "force123", Email = "yani@gmail.com", IsAdmin = false },
                    new User { UserName = "DesiDragon", Password = "drag0n", Email = "desi@gmail.com", IsAdmin = false },
                    new User { UserName = "VaskoVortex", Password = "spinspin", Email = "vasko@gmail.com", IsAdmin = false },
                    new User { UserName = "NaskoNova", Password = "galaxy", Email = "nasko@gmail.com", IsAdmin = false },
                    new User { UserName = "KrisiKnight", Password = "armor", Email = "krisi@gmail.com", IsAdmin = false },
                    new User { UserName = "BobiBlitz", Password = "zappy", Email = "bobi@gmail.com", IsAdmin = false },
                    new User { UserName = "StaniStealth", Password = "invisible", Email = "stani@gmail.com", IsAdmin = false },
                    new User { UserName = "JoroJump", Password = "hop123", Email = "joro@gmail.com", IsAdmin = false },
                    new User { UserName = "PetyaPower", Password = "strongpass", Email = "petya@gmail.com", IsAdmin = false },
                    new User { UserName = "KaloyanKing", Password = "royal", Email = "kaloyan@gmail.com", IsAdmin = false }
                };

                Users.AddRange(users);
                SaveChanges();

                // === TYPE PRODUCTS ===
                var action = new TypeProduct { Name = "Action" };
                var rpg = new TypeProduct { Name = "RPG" };
                var strategy = new TypeProduct { Name = "Strategy" };
                var adventure = new TypeProduct { Name = "Adventure" };

                TypeProducts.AddRange(new List<TypeProduct>() { action, rpg, strategy, adventure });
                SaveChanges();

                // === PRODUCTS (GAMES) ===
                var products = new List<Product>
                {
                    new Product { Name = "Grand Theft Auto V", Description = "Open-world action game", TypeProduct = action, Company = "Rockstar Games", Price = 29.99m, Quantity = 40 },
                    new Product { Name = "The Witcher 3", Description = "Fantasy RPG game", TypeProduct = rpg, Company = "CD Projekt Red", Price = 39.99m, Quantity = 50 },
                    new Product { Name = "Civilization VI", Description = "Turn-based strategy game", TypeProduct = strategy, Company = "Firaxis Games", Price = 59.99m, Quantity = 30 },
                    new Product { Name = "The Legend of Zelda: Breath of the Wild", Description = "Action-adventure game", TypeProduct = adventure, Company = "Nintendo", Price = 59.99m, Quantity = 25 },
                    new Product { Name = "Minecraft", Description = "Sandbox game", TypeProduct = adventure, Company = "Mojang", Price = 19.99m, Quantity = 200 },

                    new Product { Name = "Red Dead Redemption 2", Description = "Western-themed open-world game", TypeProduct = action, Company = "Rockstar Games", Price = 49.99m, Quantity = 35 },
                    new Product { Name = "Dark Souls III", Description = "Challenging dark fantasy RPG", TypeProduct = rpg, Company = "FromSoftware", Price = 39.99m, Quantity = 20 },
                    new Product { Name = "StarCraft II", Description = "Sci-fi real-time strategy", TypeProduct = strategy, Company = "Blizzard Entertainment", Price = 29.99m, Quantity = 15 },
                    new Product { Name = "Assassin’s Creed Valhalla", Description = "Historical action-adventure", TypeProduct = action, Company = "Ubisoft", Price = 59.99m, Quantity = 30 },
                    new Product { Name = "Hollow Knight", Description = "2D action-adventure platformer", TypeProduct = adventure, Company = "Team Cherry", Price = 14.99m, Quantity = 60 },

                    new Product { Name = "Cyberpunk 2077", Description = "Futuristic open-world RPG", TypeProduct = rpg, Company = "CD Projekt Red", Price = 49.99m, Quantity = 45 },
                    new Product { Name = "Age of Empires IV", Description = "Historical strategy game", TypeProduct = strategy, Company = "Relic Entertainment", Price = 59.99m, Quantity = 20 },
                    new Product { Name = "Hades", Description = "Rogue-like dungeon crawler", TypeProduct = rpg, Company = "Supergiant Games", Price = 24.99m, Quantity = 70 },
                    new Product { Name = "It Takes Two", Description = "Co-op action adventure", TypeProduct = adventure, Company = "Hazelight Studios", Price = 39.99m, Quantity = 50 },
                    new Product { Name = "Overwatch 2", Description = "Team-based multiplayer shooter", TypeProduct = action, Company = "Blizzard", Price = 0.00m, Quantity = 100 },

                    new Product { Name = "Final Fantasy XV", Description = "Fantasy RPG adventure", TypeProduct = rpg, Company = "Square Enix", Price = 34.99m, Quantity = 20 },
                    new Product { Name = "XCOM 2", Description = "Tactical strategy with aliens", TypeProduct = strategy, Company = "Firaxis Games", Price = 29.99m, Quantity = 25 },
                    new Product { Name = "Ori and the Will of the Wisps", Description = "Beautiful platformer adventure", TypeProduct = adventure, Company = "Moon Studios", Price = 29.99m, Quantity = 40 },
                    new Product { Name = "Far Cry 6", Description = "Action FPS in a tropical dictatorship", TypeProduct = action, Company = "Ubisoft", Price = 59.99m, Quantity = 35 },
                    new Product { Name = "Diablo IV", Description = "Dark fantasy action RPG", TypeProduct = rpg, Company = "Blizzard", Price = 69.99m, Quantity = 25 },

                    new Product { Name = "Stardew Valley", Description = "Farming and life simulation", TypeProduct = adventure, Company = "ConcernedApe", Price = 14.99m, Quantity = 100 },
                    new Product { Name = "Persona 5", Description = "Stylish turn-based JRPG", TypeProduct = rpg, Company = "Atlus", Price = 49.99m, Quantity = 20 },
                    new Product { Name = "Command & Conquer Remastered", Description = "Classic RTS with modern polish", TypeProduct = strategy, Company = "EA", Price = 19.99m, Quantity = 30 },
                    new Product { Name = "Watch Dogs: Legion", Description = "Hack your way through London", TypeProduct = action, Company = "Ubisoft", Price = 49.99m, Quantity = 22 },
                    new Product { Name = "Little Nightmares II", Description = "Spooky adventure puzzle game", TypeProduct = adventure, Company = "Tarsier Studios", Price = 29.99m, Quantity = 18 },

                    new Product { Name = "Dragon Age: Inquisition", Description = "Epic RPG fantasy world", TypeProduct = rpg, Company = "BioWare", Price = 24.99m, Quantity = 15 },
                    new Product { Name = "Total War: WARHAMMER III", Description = "Grand strategy fantasy battle sim", TypeProduct = strategy, Company = "Creative Assembly", Price = 59.99m, Quantity = 12 },
                    new Product { Name = "Metal Gear Solid V", Description = "Stealth-action open world", TypeProduct = action, Company = "Konami", Price = 19.99m, Quantity = 20 },
                    new Product { Name = "Firewatch", Description = "Story-driven walking simulator", TypeProduct = adventure, Company = "Campo Santo", Price = 19.99m, Quantity = 10 },
                    new Product { Name = "Mass Effect Legendary Edition", Description = "Sci-fi RPG trilogy remaster", TypeProduct = rpg, Company = "BioWare", Price = 49.99m, Quantity = 22 },

                    new Product { Name = "Company of Heroes 3", Description = "WWII tactical RTS", TypeProduct = strategy, Company = "Relic Entertainment", Price = 59.99m, Quantity = 13 },
                    new Product { Name = "God of War", Description = "Mythological action epic", TypeProduct = action, Company = "Santa Monica Studio", Price = 49.99m, Quantity = 28 },
                    new Product { Name = "The Forest", Description = "Survival horror game", TypeProduct = adventure, Company = "Endnight Games", Price = 19.99m, Quantity = 50 },
                    new Product { Name = "Kingdom Come: Deliverance", Description = "Realistic medieval RPG", TypeProduct = rpg, Company = "Warhorse Studios", Price = 29.99m, Quantity = 18 },
                    new Product { Name = "Northgard", Description = "Viking RTS survival strategy", TypeProduct = strategy, Company = "Shiro Games", Price = 29.99m, Quantity = 14 },

                    new Product { Name = "Batman: Arkham Knight", Description = "Superhero action game", TypeProduct = action, Company = "Rocksteady Studios", Price = 19.99m, Quantity = 26 },
                    new Product { Name = "Tunic", Description = "Zelda-inspired fox adventure", TypeProduct = adventure, Company = "Finji", Price = 29.99m, Quantity = 19 },
                    new Product { Name = "Pillars of Eternity II", Description = "Deep narrative RPG", TypeProduct = rpg, Company = "Obsidian Entertainment", Price = 34.99m, Quantity = 13 },
                    new Product { Name = "Hearts of Iron IV", Description = "Global WWII grand strategy", TypeProduct = strategy, Company = "Paradox", Price = 39.99m, Quantity = 12 },
                    new Product { Name = "Hitman 3", Description = "Stealth assassination simulator", TypeProduct = action, Company = "IO Interactive", Price = 59.99m, Quantity = 20 }

                };

                Products.AddRange(products);
                SaveChanges();

                // === ORDERS ===
                var user1 = Users.First(u => u.UserName == "ivan.petrov");
                var user2 = Users.First(u => u.UserName == "maria.georgieva");

                var order1 = new Order
                {
                    User = user1,
                    Date = DateTime.Now.AddDays(-2),
                    OrderProducts = new List<OrderProduct>
                    {
                        new OrderProduct { Product = products[0], Quantity = 1 }, // Grand Theft Auto V
                        new OrderProduct { Product = products[2], Quantity = 1 }  // Civilization VI
                    }
                };

                var order2 = new Order
                {
                    User = user2,
                    Date = DateTime.Now.AddDays(-1),
                    OrderProducts = new List<OrderProduct>
                    {
                        new OrderProduct { Product = products[1], Quantity = 1 }, // The Witcher 3
                        new OrderProduct { Product = products[3], Quantity = 2 }  // Zelda
                    }
                };

                Orders.AddRange(new List<Order>() { order1, order2 });
                SaveChanges();
            }
        }

    }
}
