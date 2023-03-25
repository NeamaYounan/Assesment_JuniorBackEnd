using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assesment_Junior_BE.Models;

namespace Assesment_Junior_BE.Repository
{
    public interface IUserAngularRepository
    {
        Task<IEnumerable<UserAngular>> GetUsers();
        Task<UserAngular> GetUserByID(int ID);
        Task<UserAngular> InsertUser(UserAngular objUser);
        Task<UserAngular> UpdateUser(UserAngular objUser);
        bool DeleteUser(int ID);
    }


    public class UserAngularRepository : IUserAngularRepository
    {
        private readonly APIDbContext _appDBContext;

        public UserAngularRepository(APIDbContext context)
        {
            _appDBContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<UserAngular>> GetUsers()
        {
            return await _appDBContext.UserAngulars.ToListAsync();
        }

        public async Task<UserAngular> GetUserByID(int ID)
        {
            return await _appDBContext.UserAngulars.FindAsync(ID);
        }

        public async Task<UserAngular> InsertUser(UserAngular objUser)
        {
            _appDBContext.UserAngulars.Add(objUser);
            await _appDBContext.SaveChangesAsync();
            return objUser;
        }

        public async Task<UserAngular> UpdateUser(UserAngular objUser)
        {
            _appDBContext.Entry(objUser).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objUser;
        }

        public bool DeleteUser(int ID)
        {
            bool result = false;
            var joging = _appDBContext.UserAngulars.Find(ID);
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

