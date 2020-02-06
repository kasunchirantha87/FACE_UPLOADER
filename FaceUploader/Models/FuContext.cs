using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceUploader.Models
{
    public class FuContext : DbContext
    {
        public FuContext(DbContextOptions<FuContext> options)
            : base(options)
        {
        }

        public DbSet<FaceMaster> FaceMaster { get; set; }
    }
}
