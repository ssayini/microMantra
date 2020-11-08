using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microMantra
{

    public class vistorContext : DbContext
    {
        public vistorContext(DbContextOptions<vistorContext> options) : base(options)
        { }
        public DbSet<visitor> visitors { get; set; }
         
    }
}