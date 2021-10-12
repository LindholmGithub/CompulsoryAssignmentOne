using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MySecurity.Data;
using MySecurity.Entities;

namespace MySecurity.Repositories
{
    public class UserRepository
    {
        private readonly SecurityContext _context;

        public UserRepository(SecurityContext context)
        {
            _context = context;
        }
        
        public IEnumerable<UserEntity> GetAll()
        {
            return _context.Users.ToList();
        }

        public UserEntity Get(long id)
        {
            return _context.Users.FirstOrDefault(b => b.Id == id);    
        }

        public void Add(UserEntity entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Edit(UserEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(long id)
        {
            var item = Get(id);
            _context.Users.Remove(item);
            _context.SaveChanges();
        }
    }
}