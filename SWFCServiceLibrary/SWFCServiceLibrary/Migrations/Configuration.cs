namespace SWFCServiceLibrary.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SWFCServiceLibrary.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {

            if (!context.Products.Any(p => p.ProductId > 0))
            {
                context.Products.Add(new Product { ImageUrl = "http://www.roligaprylar.se/media/catalog/product/cache/1/image/940x587/9df78eab33525d08d6e5fb8d27136e95/d/_/d_dsstj_rnan_bordslampa.jpg", Title = "DEATH STAR STAR BORDSLAMPA", Description = "En rymdstation som bordslampa är ju aldrig fel!", Price = 21 });
                context.Products.Add(new Product { ImageUrl = "http://www.roligaprylar.se/media/catalog/product/cache/1/image/940x587/9df78eab33525d08d6e5fb8d27136e95/2/1/21-1014506-20131121131118_1.jpg", Title = "DEATH STAR KAKBURK", Description = "Här kommer kakburken som skyddar dina kakor mot alla kakmonster.", Price = 39 });
                context.Products.Add(new Product { ImageUrl = "http://www.roligaprylar.se/media/catalog/product/cache/1/image/940x587/9df78eab33525d08d6e5fb8d27136e95/i/n/inflatable-lightsaber-90cm-infl089_lg.jpg", Title = "UPPBLÅSBART LASERSVÄRD ", Description = "Alla Star Warsfans har någon gång drömt om att fäktas med lasersvärd.", Price = 7 });
                context.Products.Add(new Product { ImageUrl = "http://www.roligaprylar.se/media/catalog/product/cache/1/image/940x587/9df78eab33525d08d6e5fb8d27136e95/s/t/star-wars-bowl-460-ml-vader-troopers.jpg", Title = "DARTH VADER FRUKOSTSKÅL", Description = "Rebellhund! Du vet redan att kriget är över. ", Price = 15 });
                context.Products.Add(new Product { ImageUrl = "http://www.roligaprylar.se/media/catalog/product/cache/1/image/940x587/9df78eab33525d08d6e5fb8d27136e95/2/1/21-23883-20130313100339.jpg", Title = "DARTH VADER MUGG", Description = "Darth Vader vill givetvis ha sitt kaffe svart.", Price = 12 });

                context.SaveChanges();
            }

        }
    }
}
