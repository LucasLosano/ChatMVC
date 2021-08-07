using System;
using System.Collections.Generic;
using System.Text;
using ChatMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Message> Messages { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
