using JewelleryShop.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Repository.Interface
{
    public interface IStaffStationRepository : IGenericRepository<StaffStation>
    {
        public Task<StaffStation> UpdateAsync(string id, StaffStation station);
        public Task DeleteAsync(string id);
    }
}
