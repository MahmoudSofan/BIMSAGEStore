using API.Entites;

namespace API.Data
{
    public static class DbIntializer
    {
        public static void Initialize(StoreContext context)
        {
            if (context.Products.Any()) return;

            var Products = GenerateUniqueRandomProductList();
            foreach (var product in Products)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();

        }
        static List<Product> GenerateUniqueRandomProductList()
        {
            List<Product> productList = new List<Product>();
            Random random = new Random();

            string[] names = { "SpectraX", "QuantumGlow", "InfinityForge", "StellarCraft", "NebulaDream", "GalacticBeam", "LunarBlaze", "SolarPulse", "StarDust", "CosmicWave", "AstroNova", "OrionSpark", "CelestialGizmo", "NebulaNectar", "CosmicWonder", "StarlightVortex", "QuantumFlare", "AstralBlast" };
            string[] descriptions = { "Futuristic gadget", "Eco-friendly marvel", "Time-traveling device", "Interstellar communicator", "Reality-bending tool", "Galactic wonder", "Lunar marvel", "Solar innovation", "Stellar powder", "Cosmic energy", "Astro phenomenon", "Orion's brilliance", "Celestial marvel", "Nebula elixir", "Cosmic enchantment", "Starlight whirlwind", "Quantum burst", "Astral explosion" };
            string[] pictureUrls = { "url1", "url2", "url3", "url4", "url5", "url6", "url7", "url8", "url9", "url10", "url11", "url12", "url13", "url14", "url15", "url16", "url17", "url18" };
            string[] brands = { "GalaxyTech", "EcoInnovations", "TimeWarp", "CosmicCommunications", "DreamCreators", "SpaceInvent", "EcoGalaxy", "TimeCraze", "CosmicDream", "StarInnovate", "AstroTech", "OrionInnovations", "CelestialSystems", "NebulaInnovate", "CosmicIndustries", "StarlightTech", "QuantumBrands", "AstralInventions" };
            string[] types = { "Gadget", "Tool", "Device", "Accessory", "Instrument", "Technology", "Innovation", "Communication", "Energy", "Exploration", "Phenomenon", "Brilliance", "Marvel", "Elixir", "Enchantment", "Whirlwind", "Burst", "Explosion" };

            for (int i = 0; i < names.Length; i++)
            {
                // Generate a unique ID for each product

                Product product = new Product
                {
                    Name = names[i],
                    Description = descriptions[i],
                    Price = (long)(random.NextDouble() * 1000), // Example price between 0 and 1000
                    PictureUrl = pictureUrls[i],
                    Brand = brands[i],
                    Type = types[i],
                    QuantityInStock = random.Next(1, 100) // Example quantity between 1 and 100
                };

                productList.Add(product);
            }

            return productList;
        }

    }
}