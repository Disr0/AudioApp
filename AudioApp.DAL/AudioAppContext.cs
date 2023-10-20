using AudioApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioApp.DAL
{
    public class AudioAppContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public AudioAppContext(DbContextOptions<AudioAppContext> options) 
            : base(options) 
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}