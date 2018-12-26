using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using SpaUserControl.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;

namespace SpaUserControl.InfraEstructure.Data.Map
{
    class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");

            //vai ver que este é um GUID e vai gerar da forma que o SQL server entenda
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name)
                .HasMaxLength(60)
                .IsRequired();

            Property(x => x.Email)
                .HasMaxLength(160)
                .HasColumnAnnotation(//criação de indice
                IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("IX_EMAIL", 1) { IsUnique = true }))
                .IsRequired();

            Property(x => x.password)
                .HasMaxLength(32)
                .IsFixedLength();

            

        }

        protected void OnModelCreating(DbModelBuilder model)
        {
            model.Configurations.Add(new UserMap());
        }
    }
}
