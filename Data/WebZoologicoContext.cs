using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebZoologico.Models;

namespace WebZoologico.Data
{
    public class WebZoologicoContext : DbContext
    {
        public WebZoologicoContext (DbContextOptions<WebZoologicoContext> options)
            : base(options)
        {
        }

        public DbSet<WebZoologico.Models.AnimalesZoologico> AnimalesZoologico { get; set; } = default!;

        public DbSet<WebZoologico.Models.Registro>? Registro { get; set; }

        public DbSet<WebZoologico.Models.Usuario>? Usuario { get; set; }
    }
}
