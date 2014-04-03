using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Breeze.ContextProvider.EF6;
using TY.Model;
using Breeze.ContextProvider;
using Newtonsoft.Json.Linq;

namespace TY.Data
{
    public class TyRepository
    {
        private readonly EFContextProvider<TyDbContext> _contextProvider = new EFContextProvider<TyDbContext>();
        private TyDbContext Context { get { return _contextProvider.Context; } }
        public string Metadata
        {
            get { return _contextProvider.Metadata(); }
        }
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }
        public IQueryable<Person> Persons
        {
            get { return Context.Persons; }
        }
        public IQueryable<Category> Categories
        {
            get { return Context.Categories; }
        }
        public IQueryable<Post> Posts
        {
            get { return Context.Posts; }
        }
    }
}
