
using Microsoft.AspNetCore.Identity;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicketApplication.Data.Repository.Imp;
using TicketApplication.Data.Repository.IRepository;
using TicketApplication.Models.Models;
using TicketApplication.Services.Interface;
using TicketApplication.Utility;

namespace TicketApplication.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IRepository<ApplicationUser> repository;
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(IRepository<ApplicationUser> service, UserManager<IdentityUser> manager)
        {
            repository = service;
            _userManager = manager;
        }

        public void Add(ApplicationUser entity)
        {
            repository.Add(entity);
        }

        public async void ChangeUserRole(string userId, SD role)
        {
            ApplicationUser user = Get(x => x.Id == userId);

            await _userManager.AddToRoleAsync(user,role.ToString());

            Update(user);
            Save(); 
        }


        public async void AddUserWithRole(string email,string password, SD role)
        {
            ApplicationUser user = new ApplicationUser
            {
                Email = email,
                PasswordHash = password
            };
            await _userManager.AddToRoleAsync(user, role.ToString());

            Update(user);
            Save();
        }

        public ApplicationUser Get(Expression<Func<ApplicationUser, bool>> filter)
        {
            return repository.Get(filter);
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return repository.GetAll();
        }

        public void Remove(ApplicationUser entity)
        {
            repository.Remove(entity);
        }

        public void RemoveRange(IEnumerable<ApplicationUser> entities)
        {
            repository.RemoveRange(entities);
        }

        public void Save()
        {
            repository.Save();
        }

        public void Update(ApplicationUser entity)
        {
           repository.Update(entity);
        }
    }
}
