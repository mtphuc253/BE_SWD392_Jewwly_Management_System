using JewelleryShop.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Repository.Interface
{
    public interface IGemstoneRepository: IGenericRepository<Gemstone>
    {
        public Task<Gemstone> UpdateAsync(string id, Gemstone gemstone);
        public Task DeleteAsync(string id);
    }
}
