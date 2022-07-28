using Job_Notification.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Notification.Data
{

    public class ApplicationDBContext : IdentityDbContext<IdentityUserCreate>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Add_jobs> Add_Jobs { get; set; }

    }


   
}
