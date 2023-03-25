
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Assesment_Junior_BE.Models;

namespace Assesment_Junior_BE.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserByID(int ID);
        Task<User> InsertUser(User objUser);
        Task<User> UpdateUser(User objUser);
        bool DeleteUser(int ID);
    }
    public class UserRepository : IUserRepository
    {

        private readonly APIDbContext _appDBContext;

        public UserRepository(APIDbContext context)
        {
            _appDBContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _appDBContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByID(int ID)
        {
            return await _appDBContext.Users.FindAsync(ID);
        }

        public async Task<User> InsertUser(User objUser)
        {
            _appDBContext.Users.Add(objUser);
            await _appDBContext.SaveChangesAsync();
            return objUser;
        }

        public async Task<User> UpdateUser(User objUser)
        {
            _appDBContext.Entry(objUser).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objUser;
        }

        public bool DeleteUser(int ID)
        {
            bool result = false;
            var joging = _appDBContext.Users.Find(ID);
            if (joging != null)
            {
                _appDBContext.Entry(joging).State = EntityState.Deleted;
                _appDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}