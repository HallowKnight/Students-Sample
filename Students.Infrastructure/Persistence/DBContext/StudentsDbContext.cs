using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Students.Domain;
using Students.Domain.AggregatesModel.LessonAggregate;
using Students.Domain.AggregatesModel.RoleAggregate;
using Students.Domain.AggregatesModel.SchoolAggregate;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Infrastructure.EntityConfiguratios;

namespace Students.Infrastructure.Persistence.DBContext
{
    public class StudentsDbContext : DbContext
    {
        public StudentsDbContext(DbContextOptions<StudentsDbContext> options) : base(options)
        {

        }
        
        
        public DbSet<User> Users { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<UserLessons> UserLessons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClassEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LessonEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SchoolEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleEntityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserRolesEntityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new UserLessonsEntityTypeConfigurations());
        }
    }
}
