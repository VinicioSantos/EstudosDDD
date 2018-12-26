using SpaUserControl.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaUserControl.InfraEstructure.Data
{
    public class DataContext : DbContext
    {

        public DataContext()
            :base("AppConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;//cria proxy do objeto, isso impede a seralização no JSON
        }

        public DbSet<User> Users { get; set; } //lista de usuarios
    }
}
