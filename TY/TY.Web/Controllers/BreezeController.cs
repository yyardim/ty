using System.Linq;
using System.Web.Http;
using TY.Model;
using TY.Data;
using Newtonsoft.Json.Linq;
using Breeze.ContextProvider;
using Breeze.WebApi2;

namespace CC.Web.Controllers
{
    [BreezeController]
    public class BreezeController : ApiController
    {
        // Todo: inject via an interface rather than "new" the concrete class
        readonly TyRepository _repository = new TyRepository();

        [HttpGet]
        public string Metadata()
        {
            return _repository.Metadata;
        }

        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _repository.SaveChanges(saveBundle);
        }

        [HttpGet]
        public IQueryable<Post> Tys()
        {
            return _repository.Posts;
        }

        [HttpGet]
        public IQueryable<Category> Categories()
        {
            return _repository.Categories;
        }

        [HttpGet]
        public IQueryable<Person> Persons()
        {
            return _repository.Persons;
        }


        /// <summary>
        /// Query returing a 1-element array with a lookups object whose 
        /// properties are all Rooms, Tracks, and TimeSlots.
        /// </summary>
        /// <returns>
        /// Returns one object, not an IQueryable, 
        /// whose properties are "rooms", "tracks", "timeslots".
        /// The items arrive as arrays.
        /// </returns>
        //[HttpGet]
        //public object Lookups()
        //{
        //    var persons = _repository.Rooms;
        //    var tracks = _repository.Tracks;
        //    var timeslots = _repository.TimeSlots;
        //    return new { rooms, tracks, timeslots };
        //}

        // Diagnostic
        [HttpGet]
        public string Ping()
        {
            return "pong";
        }
    }
}