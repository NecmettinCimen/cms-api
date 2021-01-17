using cms_api.Models;
using Microsoft.EntityFrameworkCore;

namespace cms_api.Context
{
    public class CmsContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options){
            options.EnableSensitiveDataLogging(false);
            options.UseSqlite("Data Source=CmsContext.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Experience>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Menu>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Page>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Parameter>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Project>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<ProjectTech>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Skill>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Contact>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsDeleted)
            .HasData(new User{Id=1,Email="admin", IsDeleted=false, Name="Admin", Password="123qwe", SurName="Admin"});
        }
            public DbSet<Content> Contents {get;set;}
            public DbSet<Experience> Experiences {get;set;}
            public DbSet<Menu> Menus {get;set;}
            public DbSet<Page> Pages {get;set;}
            public DbSet<Parameter> Parameters {get;set;}
            public DbSet<Project> Projects {get;set;}
            public DbSet<ProjectTech> ProjectTechs {get;set;}
            public DbSet<Skill> Skills {get;set;}
            public DbSet<User> Users {get;set;}
            public DbSet<Product> Products {get;set;}
            public DbSet<Contact> Contacts {get;set;}
    }
}