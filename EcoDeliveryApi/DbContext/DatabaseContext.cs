using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){}

    public DbSet<Mensageiro> Mensageiros { get; set; }
    public DbSet<Contribuinte> Contribuintes { get; set; }
    public  DbSet<Contribuicao> Contribuicao{ get; set; }
    public  DbSet<TipoPagamento> TipoPagamentos { get; set;}
    public DbSet<MovimentoDiario> MovimentosDiarios { get; set; }
}
