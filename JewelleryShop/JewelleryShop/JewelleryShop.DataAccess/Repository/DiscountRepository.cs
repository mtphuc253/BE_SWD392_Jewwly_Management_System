using JewelleryShop.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelleryShop.DataAccess.Models;


namespace JewelleryShop.DataAccess.Repository
{
    public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
    {
        private readonly JewelleryDBContext _context;

        public DiscountRepository(JewelleryDBContext context) : base(context)
        {
            _context = context;
        }

        public void Approve(Discount entity)
        {
            try
            {
                _context.Discounts.Update(entity);
            }
            catch(Exception ex)
            {
                throw new Exception("Cannot approve discount: " + ex.Message);
            }
        }
        
        public void Request(Discount entity)
        {
            try
            {
                _context.Discounts.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot approve discount: " + ex.Message);
            }
        }
    }
}
