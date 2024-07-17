using AutoMapper;
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Repository
{
    public class CollectionRepository : GenericRepository<Collection>,ICollectionRepository
    {
        private readonly JewelleryDBContext _dbContext;
        public CollectionRepository(JewelleryDBContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task<Collection> UpdateAsync(string id, Collection collection)
        {
            var CollectionToUpdate = await GetByIdAsync(id);
            if (CollectionToUpdate != null)
            {
                Update(collection);
                await _dbContext.SaveChangesAsync();
            }
            return collection;
        }

        public async Task DeleteAsync(string id)
        {
            var collection = await GetByIdAsync(id);
            if (collection != null)
            {
                Remove(collection);
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
