using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLoopHelper.Models;

namespace TimeLoopHelper.Data
{
  public class ApplicationDbContext : IdentityDbContext
  {
    public DbSet<Challenge> Challenges { get; set; }
    public DbSet<VerifiedTimeLoop> VerifiedTimeLoops { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
  }
}
