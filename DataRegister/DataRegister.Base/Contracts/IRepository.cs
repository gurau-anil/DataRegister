using System.Collections.Generic;
using DataRegister.Base.Models;

namespace DataRegister.Base
{
    public interface IRepository
    {
        IEnumerable<Player> Collection();
        void Commit();
        void Delete(string Id);
        Player Find(string Id);
        void Insert(Player item);
        void Update(Player item);
    }
}