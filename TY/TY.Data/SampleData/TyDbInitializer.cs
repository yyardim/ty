using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TY.Model;

namespace TY.Data
{
    public class TyDbInitializer
        : DropCreateDatabaseAlways<TyDbContext>
        //: DropCreateDatabaseIfModelChanges<TyDbContext>
    {
        protected override void Seed(TyDbContext context)
        {
            var persons = AddPeople(context, 1);
            var categories = AddCategories(context);
            var posts = AddPosts(context,persons);
        }

        private List<Person> AddPeople(TyDbContext context, int count)
        {
            var persons = new List<Person>();

            persons.Add(new Person
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                NickName = "jan",
                FirstName = "yener",
                LastName = "yardim",
                Email = "yyardim@gmail.com",
                PasswordHash = "xx",
                Active = true,
                RememberMe = true
            });

            persons.Add(new Person
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                NickName = "tan",
                FirstName = "taner",
                LastName = "tunc",
                Email = "tanertunc@gmail.com",
                PasswordHash = "xx",
                Active = true,
                RememberMe = true
            });

            persons.Add(new Person
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                NickName = "alp",
                FirstName = "alper",
                LastName = "tunc",
                Email = "alpertunc@gmail.com",
                PasswordHash = "xx",
                Active = true,
                RememberMe = true
            });

            persons.ForEach(p => context.Persons.Add(p));
            context.SaveChanges();

            return persons;
        }

        private List<Category> AddCategories(TyDbContext context)
        {
            var categories = new List<Category>();
            var categoriesFlat = new List<Category>();

            //--- I ----
            var catMain = new Category
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Name = "tyMain",
                Description = "TartisiYorum Ana Kategori"
            };

            //--- II ----
            var catSpor = new Category
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Name = "Spor",
                Description = "Spor Tartismalari",
                ParentCategories = new List<Category> { catMain }
            };

            var catFutbol = new Category
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Name = "Futbol",
                Description = "Futbol Tartismalari",
                ParentCategories = new List<Category> { catMain },
            };

            var catSiyaset = new Category
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Name = "Siyaset",
                Description = "Siyaset Tartismalari",
                ParentCategories = new List<Category> { catMain }
            };

            var catEkonomi = new Category
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Name = "Ekonomi",
                Description = "Ekonomi Tartismalari",
                ParentCategories = new List<Category> { catMain }
            };

            var catMuzik = new Category
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Name = "Muzik",
                Description = "Muzik Tartismalari",
                ParentCategories = new List<Category> { catMain }
            };

            var catSinemaTV = new Category
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Name = "Sinema & TV",
                Description = "Sinema Tartismalari",
                ParentCategories = new List<Category> { catMain }
            };

            var catSanat = new Category
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Name = "Sanat",
                Description = "Sanat Tartismalari",
                ParentCategories = new List<Category> { catMain }
            };

            var catTarih = new Category
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Name = "Tarih",
                Description = "Tarih Tartismalari",
                ParentCategories = new List<Category> { catMain }
            };

            var catTeknoloji = new Category
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Name = "Teknoloji",
                Description = "Teknoloji Tartismalari",
                ParentCategories = new List<Category> { catMain }
            };

            var catOyun = new Category
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Name = "Oyun",
                Description = "Oyun Tartismalari",
                ParentCategories = new List<Category> { catMain }
            };

            catMain.ChildCategories.Add(catSpor);
            catMain.ChildCategories.Add(catFutbol);
            catMain.ChildCategories.Add(catSiyaset);
            catMain.ChildCategories.Add(catEkonomi);
            catMain.ChildCategories.Add(catMuzik);
            catMain.ChildCategories.Add(catSinemaTV);
            catMain.ChildCategories.Add(catTarih);
            catMain.ChildCategories.Add(catSanat);
            catMain.ChildCategories.Add(catTeknoloji);
            catMain.ChildCategories.Add(catOyun);
            

            categories.Add(catMain);

            categoriesFlat = categories
                .Where(cat => cat.Name == "tyMain")
                .Flatten(cat => cat.ChildCategories)
                .ToList();

            categoriesFlat.ForEach(ty => context.Categories.Add(ty));

            context.SaveChanges();

            return categories;
        }


        private List<Post> AddPosts(TyDbContext context, List<Person> persons)
        {
            var posts = new List<Post>();
            var categories = new List<Category>();
            var categoriesFlat = context.Categories
                .Where(cat => cat.CategoryId == 1)
                .Flatten(cat => cat.ChildCategories)
                .ToList();

            var postGsSicista = new Post
            {
                DateCreated = DateTime.Now,
                Title = "Cimbom sicista",
                Content = "Valla bence oyle!!",
                Category = categoriesFlat.FirstOrDefault(t => t.Name == "Futbol"),
                Owner = context.Persons.FirstOrDefault(p => p.FirstName == "yener")
            };
            posts.Add(postGsSicista);

            var postTayyip = new Post
            {
                DateCreated = DateTime.Now,
                Title = "Tayyip serefsizin tekidir",
                Content = "Valla bence oyle!! Serefsiz.. Kesin..",
                Category = categoriesFlat.FirstOrDefault(t => t.Name == "Siyaset"),
                Owner = context.Persons.FirstOrDefault(p => p.FirstName == "yener")
            };
            posts.Add(postTayyip);

            posts.ForEach(p => context.Posts.Add(p));
            context.SaveChanges();

            posts = new List<Post>();
            var postReplyTayyip = new Post
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                ParentPostId = postTayyip.PostId,
                Content = "Evet bence de..",
                Category = categoriesFlat.FirstOrDefault(t => t.Name == "Siyaset"),
                Replier = context.Persons.FirstOrDefault(p => p.FirstName == "taner")
            };
            posts.Add(postReplyTayyip);

            var postReply2Tayyip = new Post
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                ParentPostId = postTayyip.PostId,
                Content = "Hihi bence de..",
                Category = categoriesFlat.FirstOrDefault(t => t.Name == "Siyaset"),
                Replier = context.Persons.FirstOrDefault(p => p.FirstName == "alper")
            };
            posts.Add(postReply2Tayyip);

            posts.ForEach(p => context.Posts.Add(p));
            context.SaveChanges();

            return posts;
        }
    }
}
