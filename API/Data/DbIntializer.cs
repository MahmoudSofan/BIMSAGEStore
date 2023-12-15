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

            string[] names = { "Pdf To Revit", "Cad To Revit", "Basement AutoDesign", "Column Splitter", "Base plate designer", "Model setup", "Revit pdf reader", "IFC converter", "Elec. GIS", "Fabrication QE", "Fabrication DB" };
            string[] descriptions = {
            "A plugin converts Arch. plan raster images to Revit models, by taking the JSON response of an ML model containing windows, doors, and walls coordinates, then optimizes them to create the model, including roofs, floors, and landscape.",
            "A plugin imports CAD models into the Revit projects, then creates the elements (columns-beams-slabs-foundation) in the corresponding elevation determined by the user",
            "A basement automation design plugin takes only the basement boundary walls and required car numbers as an input, then calculates the required basement stories, the optimal ramp slopes, core dimensions, the proper placement for car slots in each side, then model the whole basement ramps and slabs with slots geometrically illustrated.",
            "A plugin to split continuous columns at levels, 10 times faster than the built-in Revit API method.",
            "A visually interactive Plugin to automate anchor base plates design customization for types, dimensions, rotation, bolts, welds, and thickness.",
            "A one-window plugin to automate the whole process of creating levels, assigning view template, and creating sheets with the proper title block, legends, and view ports.",
            "A Plugin recognizes sheet numbers and sheet names from multiple PDF sheets using OCR technology and place it in Revit view sheets.",
            "A plugin exports Revit structural models with LoD 400 to an IFC format with material properties, element reinforcement hosting, for automated structural analysis.",
            "A plugin to create shared parameters for WGS84 coordinates for lighting fixtures and electrical tracks, then locate them on Azure Maps.",
            "A cost estimation plugin for MEP items with a cloud-based DB.",
            "A plugin on Autodesk Fabrication CADmep seeds the data fabrication database to PostgreSQL database related a cloud Strapi application (a Nodejs headless CMS)."};
            string[] pictureUrls = { "images/products/pdftorevit.jpg", "images/products/cadtorevit.jpg", "images/products/parking.png","images/products/column splitter.png", "images/products/BasePlate.png", "images/products/setup.jpg", "images/products/sheet.png", "images/products/ifc.jpg", "images/products/gis.png", "images/products/cost.png", "images/products/db.png", };
            string[] brands = { "BIMSAGE", "BIMSAGE", "BIMSAGE", "BIMSAGE", "BIMSAGE", "BIMSAGE", "BIMSAGE", "BIMSAGE", "BIMSAGE","BIMSAGE","BIMSAGE"};
            string[] types = { "Revit plug-in", "Revit plug-in", "Revit plug-in", "Revit plug-in","Revit plug-in", "Revit plug-in", "Revit plug-in", "Revit plug-in", "Revit plug-in", "Revit plug-in", "AutoCAD plug-in"};

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