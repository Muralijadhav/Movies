using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoviesApp.Data;
using MoviesApp.Models;
using System.IO;

namespace MoviesApp.Controllers
{
    public class MoviesController : Controller
    {
        private MoviesAppContext db = new MoviesAppContext();

        // GET: Movies
        public ActionResult Index()
        {
            List<Movie> movies = this.GetMovies();

            return View(movies);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = this.GetMovies().Where(x=>x.MovieId==id).SingleOrDefault();
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            Movie movie = new Movie();
            movie.Actors = db.Actors.ToList();

            return View(movie);
        }
        
        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Movie movie,List<Actor> actors, HttpPostedFileBase file)
        {
            
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        movie.PosterImage = "~/Images/" + _FileName;
                        string _path = Path.Combine(Server.MapPath("~/Images"), _FileName);
                        file.SaveAs(_path);
                    }
                }
                List<Actor> actorslist = movie.Actors;

                movie.Actors = null;
                db.Movies.Add(movie);
                await db.SaveChangesAsync();

                this.UpdatemovieActors(movie, actorslist);
                return RedirectToAction("Index");
            }

            return View(movie);
        }
        

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = this.GetMovies().Where(x => x.MovieId == id).SingleOrDefault();

            List<Actor> actors = movie.Actors;
            movie.Actors = new List<Actor>(); ;
            foreach (var item in db.Actors)
            {
                item.Selected = true;
                
                IEnumerable<Actor> checkactors = actors.Where(x => x.ActorId == item.ActorId);
                if (checkactors.Count() == 0)
                {
                    item.Selected = false;
                }
                movie.Actors.Add(item);
            }

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Movie movie, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0 && file!=null)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        movie.PosterImage = "~/Images/" + _FileName;

                        string _path = Path.Combine(Server.MapPath("~/Images"), _FileName);
                        file.SaveAs(_path);
                    }
                }

                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();


                this.UpdatemovieActors(movie, movie.Actors);

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = await db.Movies.FindAsync(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Movie movie = await db.Movies.FindAsync(id);
            db.Movies.Remove(movie);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();
            List<MovieActor> movieActors = db.MovieActors.ToList();
            List<Actor> actors = db.Actors.ToList();

            foreach (Movie movie in db.Movies.ToList())
            {
                Movie m = new Movie();
                m.MovieName = movie.MovieName;
                m.MovieId = movie.MovieId;
                m.Plot = movie.Plot;
                m.PosterImage = movie.PosterImage;
                m.YearOfRelease = movie.YearOfRelease;
                m.DateCreated = movie.DateCreated;
                m.DateUpdated = movie.DateUpdated;

                m.Actors = (actors.Join(movieActors.Where(z => z.Movie_MovieId == movie.MovieId), x => x.ActorId, y => y.Actor_ActorId, ((x, y) => x))).ToList<Actor>();
                movies.Add(m);
            }
            return movies;
        }

        public void UpdatemovieActors(Movie movie, List<Actor> actorslist)
        {
            int movieid = db.Movies.Where(x => x.MovieName == movie.MovieName).FirstOrDefault().MovieId;

            //List<MovieActor> movieActors = new List<MovieActor>();
            if (actorslist != null)
            {
                foreach (var item in actorslist)
                {
                    var checkexistance = db.MovieActors.Where(x => x.Movie_MovieId == movieid).Where(y => y.Actor_ActorId == item.ActorId);
                    if (checkexistance.Count() == 0 && item.Selected == true)
                    {
                        db.MovieActors.Add(new MovieActor { Movie_MovieId = movieid, Actor_ActorId = item.ActorId });
                    }
                    else if (checkexistance.Count() > 0 && item.Selected == false)
                    {
                        MovieActor movieactor = db.MovieActors.Find(movieid, item.ActorId);
                        db.MovieActors.Remove(movieactor);
                        db.SaveChanges();
                    }
                }
            }
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
