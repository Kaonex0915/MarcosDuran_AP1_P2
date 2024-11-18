using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MarcosDuran_AP1_P2.Models;

namespace MarcosDuran_AP1_P2.DAL;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
     : base(options) { }

    public DbSet<Registro> Registro { get; set; }
}
