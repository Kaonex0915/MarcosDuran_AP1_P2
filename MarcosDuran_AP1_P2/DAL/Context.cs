using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MarcosDuran_AP1_P2.Models;

namespace MarcosDuran_AP1_P2.DAL;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
     : base(options) { }

    public DbSet<RegistroCombo> RegistroCombo { get; set; }
    public DbSet<RegistroComboDetalle> RegistroComboDetalle {  get; set; }

    public DbSet <Articulos> Articulos { get; set; }

}

/*
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<RegistroCombo>().HasData
    (
        new RegistroCombo
        {
            ComboId = 1,
            Descripcion = "Monitor, mouse y teclado",
        },

        new RegistroCombo
        {
            ComboId = 2,
            Descripcion = "Computador Preensamblado",

        },

        new RegistroCombo 
        {
            ComboId = 3,
            Descripcion = "Ram, CPU y tarjeta grafica",

        },

        new RegistroCombo
        {
            ComboId = 4,
            Descripcion = "Mouse y teclado",

        },
    );

    modelBuilder.Entity<Articulos>().HasData
    (
          new Articulos
          {
              ArticuloId = 1,
              Descripcion = "Mouse",
              Costo = 700,
              Precio = 800,
              Existencia = 15,
          },

          new Articulos
          {
              ArticuloId = 2,
              Descripcion = "Monitor",
              Costo = 7000,
              Precio = 7500,
              Existencia = 6,
          },

          new Articulos
          {
              ArticuloId = 3,
              Descripcion = "Teclado",
              Costo = 2000,
              Precio = 2050,
              Existencia = 8,
          },

          new Articulos
          {
              ArticuloId = 4,
              Descripcion = "Tarjeta grafica",
              Costo = 35000,
              Precio = 38000,
              Existencia = 20,
          },

          new Articulos
          {
              ArticuloId = 5,
              Descripcion = "Ram",
              Costo = 1500,
              Precio = 1800,
              Existencia = 50,
          },
          
          new Articulos
          {
              ArticuloId  = 6,
              Descripcion = "CPU",
              Costo = 3500,
              Precio = 3000,
              Existencia = 15,
          }
    );
}

*/