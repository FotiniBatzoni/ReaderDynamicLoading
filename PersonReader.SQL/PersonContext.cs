using Microsoft.EntityFrameworkCore;
using PersonReader.Interface;
using System.Collections.Generic;

namespace PersonReader.SQL
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {
          //  Database.EnsureCreated();
        }

        public DbSet<Person>? People { get; set; }
    }
}