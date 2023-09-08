﻿using Microsoft.EntityFrameworkCore;
using PeabuxAssessment.Models;

namespace PeabuxAssessment.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
