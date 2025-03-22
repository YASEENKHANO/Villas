using GulfVillas.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfVillas.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        //this constructor is used to pass the options to the base class and base class is DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Villa> Villas { get; set; }
    }
}
