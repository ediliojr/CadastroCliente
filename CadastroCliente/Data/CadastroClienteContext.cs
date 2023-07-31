using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroCliente.Models;
using CadastroCliente.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

namespace CadastroCliente.Data
{
    public class CadastroClienteContext : DbContext
    {
        public CadastroClienteContext (DbContextOptions<CadastroClienteContext> options)
            : base(options)
        {
        }

        public DbSet<CadastroCliente.Models.Comprador> Comprador { get; set; } = default!;
        public DbSet<IdentityUserClaim<string>> aspnetuserclaims { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.

            // Customize the CadastroClienteUser entity (AspNetUsers table)
            builder.Entity<CadastroClienteUser>(entity =>
            {
                // Rename the AspNetUsers table to 'Users'
                entity.ToTable(name: "Users");

                // Example: Customize the FirstName property to have a maximum length of 50 characters
                entity.Property(u => u.FirstName).HasMaxLength(50);

                // Example: Customize the LastName property to have a maximum length of 50 characters
                entity.Property(u => u.LastName).HasMaxLength(50);


            });

            // Customize the IdentityRole entity (AspNetRoles table)
            builder.Entity<IdentityRole>(entity =>
            {
                // Rename the AspNetRoles table to 'Roles'
                entity.ToTable(name: "Roles");

            });

            // Example: Customize the IdentityUserRole entity (AspNetUserRoles table)
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey(ur => new { ur.UserId, ur.RoleId });
            });
        }

    }
}
