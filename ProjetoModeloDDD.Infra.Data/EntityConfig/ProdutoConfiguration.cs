using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(x => x.ProdutoId);

            Property(x => x.Nome).IsRequired().HasMaxLength(150);

            Property(x => x.Valor).IsRequired();

            HasRequired(x => x.Cliente)
                .WithMany()
                .HasForeignKey(x => x.ClienteId);
        }


    }
}
