using Microsoft.EntityFrameworkCore;
using Jeremy_Castillo_Ap1_p1_.Entidades;

public class Contexto:DbContext
{
    public DbSet<Productos> Productos{ get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=DATA\Productos.db");
    }
}