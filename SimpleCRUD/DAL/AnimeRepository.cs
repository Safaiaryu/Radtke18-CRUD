using SimpleCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCRUD.DAL
{
    public class AnimeRepository : IAnimeRepository
    {

        private List<Anime> anime = null;

        public AnimeRepository()
        {
            this.anime = (List<Anime>)HttpContext.Current.Session["Anime"];
        }

        public AnimeRepository(List<Anime> anime)
        {
            this.anime = anime;
        }

        /// <summary>
        /// Return all anime
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Anime> SelectAll()
        {
            return this.anime;
        }

        /// <summary>
        /// Return an anime
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Anime SelectByID(int ID)
        {
            var index = anime.FindIndex(a => a.ID == ID);

            if (index != -1) return this.anime[index];
            else 
                throw new ArgumentException("AnimeNotFound");
        }

        /// <summary>
        /// Add an anime
        /// </summary>
        /// <param name="anime"></param>
        public void Insert(Anime anime)
        {
            this.anime.Add(anime);
        }

        /// <summary>
        /// Update an anime
        /// </summary>
        /// <param name="anime"></param>
        public void Update(Anime anime)
        {
            var index = this.anime.FindIndex(a => a.ID == anime.ID);

            if (index != -1) this.anime[index] = anime;
            else throw new ArgumentException("AnimeNotFound");
        }

        /// <summary>
        /// Delete an anime
        /// </summary>
        /// <param name="ID"></param>
        public void Delete(int ID)
        {
            var index = this.anime.FindIndex(a => a.ID == ID);

            if (index != -1) this.anime.RemoveAt(index);
            else throw new ArgumentException("AnimeNotFound");
        }

        public void Save()
        {
            // Implement a save to the persistent data source
        }

        /// <summary>
        /// Find the largest ID number, increment it, and return the value
        /// </summary>
        /// <returns>int next ID value</returns>
        public int GetNextID()
        {
            return this.anime.Max(x => x.ID) + 1;
        }

        public void Dispose()
        {
            //
            // Allow the Garbage Collector to handle disposing the list of brewery objects
            //
        }
    }
}