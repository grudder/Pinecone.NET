using System.Data.Entity;

using Pinecone.Models;

namespace Pinecone.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<User> Users
        {
            get;
            set;
        }

        public virtual DbSet<VisitLog> VisitLogs
        {
            get;
            set;
        }

        public virtual DbSet<Order> Orders
        {
            get;
            set;
        }

        public virtual DbSet<JumpUser> JumpUsers
        {
            get;
            set;
        }

        public virtual DbSet<JumpVisitLog> JumpVisitLogs
        {
            get;
            set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}