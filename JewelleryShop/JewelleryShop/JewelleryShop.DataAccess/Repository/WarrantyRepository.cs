using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Repository
{
    public class WarrantyRepository : GenericRepository<Warranty>, IWarrantyRepository
    {
        private readonly JewelleryDBContext _dbContext;
        public WarrantyRepository(JewelleryDBContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<Warranty> AddWarranty(Warranty warranty)
        {
            warranty.WarrantyId = Guid.NewGuid().ToString();
            if (warranty.ExpiryDate <= warranty.CreatedDate)
            {
                throw new ArgumentException("Warranty expiry date cannot be equal or less than created date.");
            }
            warranty.ExpiryDate = warranty.ExpiryDate;
            warranty.CreatedDate = DateTime.Now;
            await _dbContext.AddAsync(warranty);
            return warranty;
        }
    }
}
