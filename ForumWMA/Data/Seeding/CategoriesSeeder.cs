namespace ForumWMA.Data.Seeding
{
    using ForumWMA.Data.Models;
    using ForumWMA.Data.Seeding.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ForumWMADbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new List<string>() { "Sport", "Coronavirus", "News", "Programming", "Cats", "Dogs", "Art" };
            foreach (var category in categories)
            {
                string imageUrl = string.Empty;
                switch (category)
                {
                    case "Sport":
                        imageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fmumbrella.com.au%2Fwhen-it-comes-to-sports-marketing-australia-isnt-competitive-enough-585992&psig=AOvVaw2g91pqacZZGtnoraGHP3-b&ust=1593264352603000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCKDc27HKn-oCFQAAAAAdAAAAABAD";
                        break;
                    case "Coronavirus":
                        imageUrl = "https://www.ub.edu/eurosla2020/wp-content/uploads/2020/03/CORONAVIRUS.jpg";
                        break;
                    case "News":
                        imageUrl = "https://youngfreeflorida.com/wp-content/uploads/2019/06/Marketplace-Lending-News.jpg";
                        break;
                    case "Programming":
                        imageUrl = "https://www.pentasia.com/rails/active_storage/representations/eyJfcmFpbHMiOnsibWVzc2FnZSI6IkJBaHBBaXhwIiwiZXhwIjpudWxsLCJwdXIiOiJibG9iX2lkIn19--9b531a296e23edbb0ae0d85e4160a44a71b44f8e/eyJfcmFpbHMiOnsibWVzc2FnZSI6IkJBaDdCam9VWTI5dFltbHVaVjl2Y0hScGIyNXpld2c2QzNKbGMybDZaVWtpRGpFd01EQjROVEF3WGdZNkJrVlVPZ3huY21GMmFYUjVTU0lMUTJWdWRHVnlCanNIVkRvSlkzSnZjRWtpRVRFd01EQjROVEF3S3pBck1BWTdCMVE9IiwiZXhwIjpudWxsLCJwdXIiOiJ2YXJpYXRpb24ifX0=--46c71b34483be69bdb6c526f3ee4da2b74b4cce2/1662_original.jpg";
                        break;
                    case "Cats":
                        imageUrl = "https://www.rd.com/wp-content/uploads/2019/09/Cute-cat-lying-on-his-back-on-the-carpet.-Breed-British-mackerel-with-yellow-eyes-and-a-bushy-mustache.-Close-up-e1573490045672.jpg";
                        break;
                    case "Dogs":
                        imageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTS29eOeWxM6SaR_-xwIEjtve3k7BiYTh2353JPBtyf0LMGaviy&usqp=CAU";
                        break;
                    case "Art":
                        imageUrl = "https://www.castlefineart.com/assets/img/uploads/jmy-peach-trees-in-bloom-thumbnail_2020-02-03T13-57-24.jpg";
                        break;
                }

                await dbContext.Categories.AddAsync(new Category()
                {
                    Name = category,
                    CreatedOn = DateTime.UtcNow,
                    Description = category,
                    Title = category,
                    ImageUrl = imageUrl,
                });
            }
        }
    }
}
