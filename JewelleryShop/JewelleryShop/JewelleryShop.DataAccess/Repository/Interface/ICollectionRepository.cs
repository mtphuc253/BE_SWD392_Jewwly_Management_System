using JewelleryShop.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Repository.Interface
{
    public interface ICollectionRepository:IGenericRepository<Collection>
    {
        public Task<Collection> UpdateAsync(string id, Collection collection);
        public Task DeleteAsync(string id);
    }
}
