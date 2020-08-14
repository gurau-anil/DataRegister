namespace DataRegister.SQL
{
    using DataRegister.Base.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataContext : DbContext
    {
        public DataContext()
            : base("DataContext")
        {
        }

        public DbSet<Player> Players { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}