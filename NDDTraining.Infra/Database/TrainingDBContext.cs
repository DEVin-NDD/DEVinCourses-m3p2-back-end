using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NDDTraining.Domain.Models;


namespace NDDTraining.Infra.Database
{
  public class TrainingDBContext : DbContext
  {
    public DbSet<Module> Modules { get; set; }
    public DbSet<Registration> Registrations { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<User> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      base.OnConfiguring(optionsBuilder);

      optionsBuilder.UseSqlServer(
          _configuration.GetConnectionString("NDDTraining")
      );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //modelBuilder.ApplyConfiguration(new ModuleMap());
      //modelBuilder.ApplyConfiguration(new RegistrationMap());
      //modelBuilder.ApplyConfiguration(new TrainingMap());
      //modelBuilder.ApplyConfiguration(new UserMap());
    }
  }
}

