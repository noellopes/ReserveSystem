﻿using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
     
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) {}


        public DbSet<DaysOffAndVacations> DaysOffAndVacations { get; set; }
      //  public DbSet<Staff> Staff { get; set; }
    }
}
