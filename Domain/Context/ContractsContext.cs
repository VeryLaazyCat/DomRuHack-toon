using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Domain
{
    public class ContractsContext : DbContext
    {
        public DbSet<ContractInfo> ContractInfos { get; set; }


        public string DbPath { get; private set; }
        public ContractsContext(DbContextOptions<ContractsContext> options)
            : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}contracts.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
