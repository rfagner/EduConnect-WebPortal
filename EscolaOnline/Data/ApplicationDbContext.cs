using EscolaOnline.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EscolaOnline.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<AcademicActivity> AcademicActivities { get; set; }
    public DbSet<Video> Videos { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<News> News { get; set; }
}
