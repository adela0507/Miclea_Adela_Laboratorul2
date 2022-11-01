using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Miclea_Adela_Laboratorul2.Models;

namespace Miclea_Adela_Laboratorul2.Data
{
    public class Miclea_Adela_Laboratorul2Context : DbContext
    {
        public Miclea_Adela_Laboratorul2Context (DbContextOptions<Miclea_Adela_Laboratorul2Context> options)
            : base(options)
        {
        }

        public DbSet<Miclea_Adela_Laboratorul2.Models.Book> Book { get; set; } = default!;

        public DbSet<Miclea_Adela_Laboratorul2.Models.Publisher> Publisher { get; set; }

        public DbSet<Miclea_Adela_Laboratorul2.Models.Author> Author { get; set; }

        public DbSet<Miclea_Adela_Laboratorul2.Models.Category> Category { get; set; }
    }
}
