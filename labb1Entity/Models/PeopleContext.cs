using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace labb1Entity.Models
{
    public class PeopleContext : DbContext
    {
        public DbSet<ApplicationForLeave> ApplicationForLeaves{ get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-8957B06\SQLEXPRESS;Initial Catalog=ApplicationForLeave;Integrated Security=True;");
        }
    }
}
