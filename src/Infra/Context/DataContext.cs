using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
