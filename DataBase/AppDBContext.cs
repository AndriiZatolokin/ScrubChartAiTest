using Microsoft.EntityFrameworkCore;
using ScrubChartAiTest.Models;
using System;

namespace ScrubChartAiTest.DataBase
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visit> Visits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=localhost;Database=ScrubChart;Port=5432;User Id =postgres;Password=PGAdmin;");
    }
}
