using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicketApplication.Models.Models;
using TicketApplication.Utility;

namespace TicketApplication.Services.Interface
{
    public interface IUserService
    {

        IEnumerable<ApplicationUser> GetAll();
        ApplicationUser Get(Expression<Func<ApplicationUser, bool>> filter);
        void Add(ApplicationUser entity);
        //void Update(T entity);
        void Remove(ApplicationUser entity);
        void RemoveRange(IEnumerable<ApplicationUser> entities);

        void ChangeUserRole(string userId, SD role);

        void Update(ApplicationUser entity);

        void AddUserWithRole(string email, string password, SD role);
        void Save();
    }
}
