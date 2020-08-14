using DataRegister.Base.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRegister.SQL
{
    public class SqlRepository
    {
        DataContext context;
        DbSet<Player> player;
        public SqlRepository()
        {
            context = new DataContext();
            player=context.Players;
        }
        public void Commit()
        {
            context.SaveChanges();
        }
        public IEnumerable<Player> Collection()
        {
            return player as IEnumerable<Player>;
        }
        public void Insert(Player item)
        {
            player.Add(item);
        }
        public Player Find(string Id)
        {
            return player.Find(Id);
        }
        public void Delete(string Id)
        {
            var item = Find(Id);
            if (context.Entry(item).State == EntityState.Deleted)
            {
                player.Attach(item);
            }
            player.Remove(item);
        }

        public void Update(Player item)
        {
            player.Attach(item);
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
