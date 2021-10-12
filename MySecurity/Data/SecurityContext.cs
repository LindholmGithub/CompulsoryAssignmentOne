using Microsoft.EntityFrameworkCore;
using MySecurity.Entities;
using System;
using System.Collections.Generic;


namespace MySecurity.Data
{
    public class SecurityContext : DbContext
    {
        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options) {}

        public DbSet<UserEntity> Users { get; set; }

    }
}