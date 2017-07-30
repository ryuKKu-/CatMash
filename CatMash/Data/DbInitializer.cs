using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace CatMash.Data
{
    public class DbInitializer
    {
        private class CatModel
        {
            public string Url { get; set; }
            public string Id { get; set; }
        }

        /// <summary>
        /// Initialize and seed database only if no context exists
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(CatMashContext context)
        {
            context.Database.EnsureCreated();

            if (context.Cats.Any())
                return;

            if (File.Exists("cats.json"))
            {
                var catModels = JsonConvert.DeserializeObject<List<CatModel>>(File.ReadAllText("cats.json"));

                var cats = new List<Cat>();

                foreach (var c in catModels)
                    context.Cats.Add(new Cat
                    {
                        CatId = c.Id,
                        ImageUrl = c.Url,
                        Looses = 0,
                        Wins = 0,
                        Rating = 1200,
                    });

                context.SaveChanges();
            }
        }
    }
}
