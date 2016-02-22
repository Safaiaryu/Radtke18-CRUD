using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleCRUD.Models;
using SimpleCRUD.DAL;

namespace SimpleCRUD.Controllers
{
    public class AnimeController : Controller
    {
        private IAnimeRepository ar = null;
        // GET: Anime

        public AnimeController()
        {
            this.ar = new AnimeRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowTable()
        {
            return View(ar.SelectAll());
        }

        public ActionResult ShowList()
        {
            return View(ar.SelectAll());
        }

        public ActionResult ShowDetail(int id)
        {
            return View(ar.SelectByID(id));
        }

        public ActionResult DeleteAnime(int id)
        {
            return View(ar.SelectByID(id));
        }

        [HttpPost]
        public ActionResult DeleteAnime(FormCollection form)
        {
            if (form["operation"] == "Delete")
            {
                ar.Delete(Convert.ToInt32(form["ID"]));
            }

            return Redirect("/Anime/ShowTable");
        }

        public ActionResult CreateAnime()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAnime(FormCollection form)
        {
            if (form["operation"] == "Add")
            {
                Anime newAnime = new Anime()
                {
                    ID = ar.GetNextID(),
                    Title = form["title"],
                    Publisher = form["publisher"],
                    Author = new Author(form["firstName"], form["lastName"]),
                    Description = form["description"],
                    Genre = (GenreEnum.Genre)Enum.Parse(typeof(GenreEnum.Genre), form["genre"]),
                    Season = (SeasonEnum.Season)Enum.Parse(typeof(SeasonEnum.Season), form["season"]),
                    ReleaseDate = Convert.ToDateTime(form["releaseDate"]),
                    Rating = Convert.ToDouble(form["rating"]),
                    Aring = Convert.ToBoolean(form["aring"])
                };

                ar.Insert(newAnime);
            }

            return Redirect("/Anime/ShowTable");
        }

        public ActionResult UpdateAnime(int id)
        {
            return View(ar.SelectByID(id));
        }

        [HttpPost]
        public ActionResult UpdateAnime(FormCollection form)
        {
            if (form["operation"] == "Edit")
            {
                Anime updatedAnime = new Anime()
                {
                    ID = Convert.ToInt32(form["ID"]),
                    Title = form["title"],
                    Publisher = form["publisher"],
                    Author = new Author(form["firstName"], form["lastName"]),
                    Description = form["description"],
                    Genre = (GenreEnum.Genre)Enum.Parse(typeof(GenreEnum.Genre), form["genre"]),
                    Season = (SeasonEnum.Season)Enum.Parse(typeof(SeasonEnum.Season), form["season"]),
                    ReleaseDate = Convert.ToDateTime(form["releaseDate"]),
                    Rating = Convert.ToDouble(form["rating"]),
                    Aring = Convert.ToBoolean(form["aring"])

                };

                ar.Update(updatedAnime);
            }

            return Redirect("/Anime/ShowTable");
        }

        public ActionResult ReloadData()
        {
            SimpleCRUD.DAL.Data.InitializeAnime();

            return Redirect("/Anime/ShowTable");
        }
       
    }
}