using Cosource.DataAccess.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cosource.DataAccess.Data.Context
{
    class CosourceContext : DbContext
    {
        public DbSet<ProductDataModel>  ProductCatalogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\javie\source\repos\Cosource.Scrap\Cosource.DataAccess\Data\Mdf\Cosource.mdf;Integrated Security=True;Connect Timeout=30");
    }
}
