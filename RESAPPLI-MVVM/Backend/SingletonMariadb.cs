﻿using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using RESAPPLI_MVVM.Models;

namespace RESAPPLI_MVVM.Data
{
    public class SingletonMariadb : DbContext
    {
        private static SingletonMariadb instance;

        public DbSet<Entreprise> Entreprises { get; set; }

        private SingletonMariadb(DbContextOptions<SingletonMariadb> options) : base(options) { }

        public static SingletonMariadb GetInstance()
        {
            if (instance == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<SingletonMariadb>();
                var connectionString = "Server=localhost;Database=RES;Uid=RES;Pwd=azerty123!!!;";
                var serverVersion = new MariaDbServerVersion(new Version(10, 4, 8));

                optionsBuilder.UseMySql(connectionString, serverVersion);

                var options = optionsBuilder.Options;
                instance = new SingletonMariadb(options);
            }

            return instance;
        }
    }
}