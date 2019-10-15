﻿using Microsoft.EntityFrameworkCore;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.DataAccess.EF._DatabaseContext
{
    public class DatabaseContext:DbContext
    {
        // Haktan=> you can check to added database and entities.After you add migration 
        //To add migrations =>you should do at the following steps=> 1. Open CMD => 2.dotnet ef migrations add "..." => 3. dotnet ef database update .. 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-7DBO8O5\SQLEXPRESS;Database=OneBoardV2;User ID=kullanici;Password=1234;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            optionsBuilder.UseSqlServer(connectionString: @"Data Source=DESKTOP-BFT7NEM\SQLEXPRESS;Database=OneBoardV2;Trusted_Connection=true");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<DataSource>().HasMany(w=>w.Widgets).WithRequired().WillCascadeOnDelete(false);
        //}
        public DbSet<ChartType> ChartTypes { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<UserFirm> UserFirms{ get; set; }
        public DbSet<Group> Groups{ get; set; }
        public DbSet<UserGroup> UserGroups{ get; set; }
        public DbSet<Widget> Widgets{ get; set; }
        public DbSet<WidgetType> WidgetTypes{ get; set; }
        public DbSet<Dashboard> Dashboards{ get; set; }
        public DbSet<DataSource> DataSources{ get; set; }
        public DbSet<DataSourceType> DataSourceTypes{ get; set; }
        public DbSet<Serie> Series{ get; set; }
        public DbSet<Firm> Firms { get; set; }
    }
}