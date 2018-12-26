using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

public class ProjetoModeloContext : DbContext
    
{
    public ProjetoModeloContext()
        : base("ProjetoModeloDDD")
    {

    }

    public DbSet<Cliente> Clientes { get; set; }
}
