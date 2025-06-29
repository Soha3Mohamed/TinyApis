﻿using Microsoft.EntityFrameworkCore;

namespace BookApi.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        public DbSet<Book> Books { get; set; }
    }
}
