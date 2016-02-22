using SimpleCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCRUD.DAL
{
    public interface IAnimeRepository : IDisposable
    {
        IEnumerable<Anime> SelectAll();
        Anime SelectByID(int ID);
        void Insert(Anime anime);
        void Update(Anime anime);
        void Delete(int ID);
        void Save();
        int GetNextID();
    }
}