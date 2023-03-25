using Assesment_Junior_BE.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace Assesment_Junior_BE.Repository
{
    public interface IJogingRepository
    {
        Task<IEnumerable<Joging>> GetJoging();
        Task<Joging> GetJogingByID(int ID);
        Task<Joging> InsertJoging(Joging objJoging);
        Task<Joging> UpdateJoging(Joging objJogin);
        bool DeleteJoging(int ID);
    }

    public class JogingRepository : IJogingRepository
    {

        private readonly APIDbContext _appDBContext;

        public JogingRepository(APIDbContext context)
        {
            _appDBContext = context ?? throw new ArgumentNullException(nameof(context));
        }        

        public async Task<IEnumerable<Joging>> GetJoging()
        {
            return await _appDBContext.Jogings.ToListAsync();
        }

        public async Task<Joging> GetJogingByID(int ID)
        {
            return await _appDBContext.Jogings.FindAsync(ID);
        }

        public async Task<Joging> InsertJoging(Joging objJoging)
        {
            _appDBContext.Jogings.Add(objJoging);
            await _appDBContext.SaveChangesAsync();
            return objJoging;

        }

        public async Task<Joging> UpdateJoging(Joging objJoging)
        {
            _appDBContext.Entry(objJoging).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objJoging;

        }

        public bool DeleteJoging(int ID)
        {
            bool result = false;
            var joging = _appDBContext.Jogings.Find(ID);
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