using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Repository
{
    public class StaffStationRepository : GenericRepository<StaffStation>, IStaffStationRepository
    {
        private readonly JewelleryDBContext _dbContext;
        public StaffStationRepository(JewelleryDBContext context) : base(context)
        {
            _dbContext = context;
        }
        public async Task<StaffStation> UpdateAsync(string id, StaffStation station)
        {
            var StationToUpdate = await GetByIdAsync(id);
            if (StationToUpdate != null)
            {
                Update(station);
                await _dbContext.SaveChangesAsync();
            }
            return station;
        }

        public async Task DeleteAsync(string id)
        {
            var station = await GetByIdAsync(id);
            if (station != null)
            {
                Remove(station);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
