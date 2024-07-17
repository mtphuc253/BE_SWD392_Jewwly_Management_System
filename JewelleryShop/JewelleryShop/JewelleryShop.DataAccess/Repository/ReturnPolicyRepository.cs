using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Repository
{

    public class ReturnPolicyRepository : GenericRepository<ReturnPolicy>, IReturnPolicyRepository
    {
        private readonly JewelleryDBContext _dbContext;
        public ReturnPolicyRepository(JewelleryDBContext context) : base(context)
        {
            _dbContext = context;
        }

    }
}
