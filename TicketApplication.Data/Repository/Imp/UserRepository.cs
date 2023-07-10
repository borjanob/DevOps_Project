using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicketApplication.Data.Data;
using TicketApplication.Data.Repository.IRepository;
using TicketApplication.Models.Models;

namespace TicketApplication.Data.Repository.Imp
{
    public class UserRepository : IRepository<ApplicationUser>
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<ApplicationUser> _dbSet;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<ApplicationUser>();
        }


        public void Add(ApplicationUser entity)
        {
            _dbSet.Add(entity);
        }

        public ApplicationUser Get(Expression<Func<ApplicationUser, bool>> filter)
        {
            IQueryable<ApplicationUser> query = _dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            IQueryable<ApplicationUser> query = _dbSet;
            return query.ToList();
        }

        public void Remove(ApplicationUser entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<ApplicationUser> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Save()
        {

            _context.SaveChanges();
        }

        public void Update(ApplicationUser entity)
        {
            _context.Update(entity);
        }
    }
}
