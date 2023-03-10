using Management.Domain.Enums;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infraestructure
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                    .Entity<MovementType>()
                    .HasData(Enum.GetValues(typeof(MovementTypeEnum))
                        .Cast<MovementTypeEnum>()
                        .Select(e => new MovementType
                        {
                            Id = (short)e,
                            Name = e.ToString()
                        })
            );
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<MovementType> MovementTypes { get; set; }
    }
}
