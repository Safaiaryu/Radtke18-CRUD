using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleCRUD.Models;

namespace SimpleCRUD.Controllers
{
    public class AnimeController : Controller
    {
        // GET: Anime
        public ActionResult Index()
        {
            if (Session["ActiveAnimeSession"] == null)
            {
                Session["Anime"] = InitialAnime();
                Session["ActiveAnimeSession"] = true;
            }

            return View();
        }

        public ActionResult ShowTable()
        {
            List<Anime> anime = (List<Anime>)Session["Anime"];

            Session["Anime"] = anime;

            return View(anime);
        }

        public ActionResult ShowList()
        {
            List<Anime> anime = (List<Anime>)Session["Anime"];

            Session["Anime"] = anime;

            return View(anime);
        }

        public ActionResult ShowDetail(int id)
        {
            List<Anime> anime = (List<Anime>)Session["Anime"];

            int index = anime.FindIndex(a => a.ID == id);

            Anime ani = anime[index];

            return View(ani);
        }

        public ActionResult DeleteAnime(int id)
        {
            List<Anime> anime = (List<Anime>)Session["Anime"];
            Anime animeToDelete = null;

            foreach (Anime Anime in anime)
            {
                if (Anime.ID == id)
                {
                    animeToDelete = Anime;
                }
            }

            return View(animeToDelete);
        }

        [HttpPost]
        public ActionResult DeleteAnime(FormCollection form)
        {
            if (form["operation"] == "Delete")
            {
                List<Anime> anime = (List<Anime>)Session["Anime"];

                int index = anime.FindIndex(a => a.ID == Convert.ToInt32(form["ID"]));

                anime.RemoveAt(index);

                Session["Anime"] = anime;

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
                List<Anime> anime = (List<Anime>)Session["Anime"];

                Anime newAnime = new Anime()
                {
                    ID = GetNextID(),
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

                anime.Add(newAnime);

                Session["Anime"] = anime;

            }

            return Redirect("/Anime/ShowTable");
        }

        public ActionResult UpdateAnime(int id)
        {
            List<Anime> anime = (List<Anime>)Session["Anime"];
            Anime animeToUpdate = null;

            foreach (Anime ani in anime)
            {
                if (ani.ID == id)
                {
                    animeToUpdate = ani;
                }
            }

            return View(animeToUpdate);
        }

        [HttpPost]
        public ActionResult UpdateAnime(FormCollection form)
        {
            if (form["operation"] == "Edit")
            {
                List<Anime> anime = (List<Anime>)Session["Anime"];

                int index = anime.FindIndex(a => a.ID == Convert.ToInt32(form["ID"]));

                anime[index].Title = form["title"];
                anime[index].Publisher = form["publisher"];
                anime[index].Author.FirstName = form["firstName"];
                anime[index].Author.LastName = form["lastName"];
                anime[index].Description = form["description"];
                anime[index].Genre = (GenreEnum.Genre)Enum.Parse(typeof(GenreEnum.Genre), form["genre"]);
                anime[index].Season = (SeasonEnum.Season)Enum.Parse(typeof(SeasonEnum.Season), form["season"]);
                anime[index].ReleaseDate = Convert.ToDateTime(form["releaseDate"]);
                anime[index].Rating = Convert.ToDouble(form["rating"]);
                anime[index].Aring = Convert.ToBoolean(form["aring"]);

                Session["Anime"] = anime;

            }

            return Redirect("/Anime/ShowTable");
        }

        public ActionResult ReloadData()
        {
            Session["Anime"] = InitialAnime();

            return Redirect("/Anime/ShowTable");
        }

        private int GetNextID()
        {
            List<Anime> anime = (List<Anime>)Session["Anime"];

            return anime.Max(x => x.ID) + 1;
        }


        //Create Data
        private List<Anime> InitialAnime()
        {
            List<Anime> anime = new List<Anime>();

            anime.Add(new Anime
            {
                ID = 1,
                Title = "Dagashi Kashi",
                Publisher = "Feel",
                Author = new Author("Koto", "Yama"),
                Description = "Shikada Kokonotsu's father owns a rural sweets shop," +
                                "and his plan is for Kokonotsu to take it over one day. " +
                                "However, Kokonotsu wants to be a manga author instead! " +
                                "One day in summer, the cute but weird girl Shidare Hotaru, " +
                                "from the famous sweets company, comes to pay a visit. Apparently, " +
                                "Kokonotsu's father is famous and she wants him to join her family's " +
                                "company. However, he will only agree if she can convince Kokonotsu to" +
                                "take over the family business!" ,
                ReleaseDate = new DateTime(2016, 01, 08),
                Genre = GenreEnum.Genre.Comedy,
                Rating = 7.14,
                Aring = true
            });

            anime.Add(new Anime
            {
                ID = 2,
                Title = "Kono Subarashii Sekai ni Shukufuku wo!",
                Publisher = "Studio Deen",
                Author = new Author("Akatsuki", "Natsume"),
                Description = "Kazuma Satou, a high school student, gamer and shut-in, died " +
                                "on an average day walking home from school, performing the one " +
                                "heroic act of his life. He reawakens in the afterlife, greeted by " +
                                "a beautiful but rude girl named Aqua, who claims to be a goddess that "  +
                                "guides the youth whose lives got cut short. Aqua then offers him a " +
                                "choice: to go to heaven, or to get sent to a another world to defeat the " +
                                "Demon King. Of course, Kazuma's gamer instincts kick in, and he chooses " +
                                "to start a new life in a real-life RPG. There's one last choice Kazuma has " +
                                "to make: he is allowed the choice of one thing to take with him to the new" +
                                "world. After puzzling over it, he chooses...Aqua?",
                ReleaseDate = new DateTime(2016, 01, 14),
                Genre = GenreEnum.Genre.Adventure,
                Rating = 7.84,
                Aring = true
            });

            anime.Add(new Anime
            {
                ID = 3,
                Title = "Boku dake ga Inai Machi",
                Publisher = "A-1 Pictures",
                Author = new Author("Kei", "Sanbe"),
                Description = "Satoru Fujinuma is a 29 year old manga artist struggling to make a name for himself " +
                                "following his debut. But, that was not the only thing in his life that Satoru was feeling " +
                                "frustrated about… He has a unique supernatural ability of being forced to prevent deaths and " +
                                "catastrophes by being sent back in time before the incident occurred, repeating time until the " +
                                "accident is prevented. One day, he gets involved in an accident that has him framed as a murderer. " +
                                "Desperate to save the victim, he sends himself back in time only to find himself as a grade-schooler " +
                                "one month before fellow classmate Kayo Hinazuki went missing. Satoru now embarks on a new quest: to " +
                                "save Kayo and solve the mystery behind her disappearance.",
                ReleaseDate = new DateTime(2016, 01, 08),
                Genre = GenreEnum.Genre.Mystery,
                Rating = 9.11,
                Aring = true
            });

            return anime;
        }
    }
}