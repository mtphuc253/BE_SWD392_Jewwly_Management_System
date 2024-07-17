using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Repository
{
    public class GemstoneRepository : GenericRepository<Gemstone>, IGemstoneRepository
    {
        private readonly JewelleryDBContext _dbContext;
        public GemstoneRepository(JewelleryDBContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task<Gemstone> UpdateAsync(string id, Gemstone gemstone)
        {
            var GemUpdate = await GetByIdAsync(id);
            if (GemUpdate != null)
            {
                Update(gemstone);
                await _dbContext.SaveChangesAsync();
            }
            return gemstone;
        }

        public async Task DeleteAsync(string id)
        {
            var GemDel = await GetByIdAsync(id);
            if (GemDel != null)
            {
                Remove(GemDel);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
