
namespace Jacustran.Client.Components.ModularComponents;

public partial class ProductList
{
    private static List<Product> _products = new List<Product>()
    {
        new("Miso") 
        { 
            Id = Guid.NewGuid(), 
            Description = "Miso is a traditional Japanese seasoning. It is a thick paste produced by fermenting soybeans with salt and kōji (the fungus Aspergillus oryzae) and sometimes rice, barley, seaweed, or other ingredients. Miso is used for sauces and spreads, pickling vegetables, fish, or meats, and mixing with dashi soup stock to serve as miso soup, a Japanese culinary staple. It is high in protein and rich in vitamins and minerals, playing an important nutritional role in feudal Japan. Miso is still widely used in both traditional and modern cooking in Japan and has been gaining worldwide interest. The flavor and aroma of miso depend on the ingredients and fermentation process, resulting in varieties described as salty, sweet, earthy, fruity, and savory", 
            ImageUrl = "", 
            Price = 14.75m
        },
        new("Soy sauce") 
        {
            Id = Guid.NewGuid(),
            Description = "Soy sauce, a traditional East and Southeast Asian liquid condiment, is made from fermented soybeans, wheat, yeast, and salt. It plays a prominent role in Japanese Cuisine among others",
            ImageUrl = "",
            Price = 15.85m
        },
        new("Mirin") 
        { 
            Id = Guid.NewGuid(),
            Description = "Mirin is a Japanese sweet rice wine made by fermenting a combination of steamed mochi rice, koji (fermented rice), and shochu (sweet potato alcohol) for 40 to 60 days12. This slightly viscous and yellowish seasoning is an essential component of traditional Japanese cuisine. Its unique production process results in a sweet rice wine with 14% alcohol content, which imparts a delicate balance of alcohol and sweetness. Mirin’s versatility allows it to enhance not only pan-fried dishes but also stews and various other recipes.",
            ImageUrl = "",
            Price = 11.99m
        }
    };
}