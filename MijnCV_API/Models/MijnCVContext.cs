using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using MijnCV_API.Models;

namespace MijnCV_API.Models
{
    public class MijnCVContext : DbContext
    {
        public MijnCVContext(DbContextOptions<MijnCVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User>? Users { get; set; }

        public virtual DbSet<Section>? Sections { get; set; }

        public virtual DbSet<Page>? Pages { get; set; }

        public virtual DbSet<Statistics>? Statistics { get; set; }
    }
}