using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using LojaWeb.Models;

namespace LojaWeb.Data;

public partial class VsproContext : DbContext
{
    public VsproContext()
    {
    }

    public VsproContext(DbContextOptions<VsproContext> options)
        : base(options)
    {
    }
    public DbSet<Departamento> Departamento {get; set;}
      public DbSet<RegistroVendas> RegistroVendas {get; set;}
       public DbSet<Vendedor> Vendedor {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){} 
   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
