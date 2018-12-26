using SpaUserControl.Domain.Contracts.Repositories;
using SpaUserControl.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaUserControl.InfraEstructure.Data.Repositories
{
    //Aqui acontece a implementação do repository
    public class UserRepository : IUserRepository
    {

        private DataContext _context;

        public UserRepository(DataContext context)
        {
            this._context = context;
        }

        public User Get(string email)
        {
            return _context.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public List<User> Get(int skip, int take)
        {
            return _context.Users.OrderBy(x => x.Name).Skip(skip).Take(take).ToList();
        }

        public User Get(Guid id)
        {
            return _context.Users.Where(x => x.Id == id).FirstOrDefault(); //Cria uma instancia de um Dbset
        }

        public void Create(User user)
        {
            _context.Users.Add(user);// salvo na sessão
            _context.SaveChanges();//persisto no banco
        }
        public void Update(User user)
        {
            _context.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public void Dispose()
        {
            _context.Dispose();
        }




    }
}
