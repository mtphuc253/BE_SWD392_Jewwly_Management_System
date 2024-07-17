using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.dto;
using JewelleryShop.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JewelleryShop.DataAccess.Repository
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        private readonly JewelleryDBContext _context;
        public ItemRepository(JewelleryDBContext context) : base(context)
        {
            _context = context;
        }
        public void SoftDelete(Item item)
        {
            try
            {
                _context.Items.Update(item);
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot update status item:" + ex.Message);
            }
        }

        public List<Item> GetByName(string itemName) 
        {
            var items = _context.Items.AsQueryable();
            if (!string.IsNullOrEmpty(itemName))
            {
                items = items.Where(Item => Item.ItemName.Contains(itemName));
            }
            var result = items.Select(Item => new Item
            {
                ItemId = Item.ItemId,
                ItemName = Item.ItemName,
                SerialNumber = Item.SerialNumber,
                Price = Item.Price,
                AccessoryType = Item.AccessoryType
            });
            return result.ToList();
        }

        public async Task<List<Item>> GetAllBuyBackAsync()
        {
            var items = await _context.Items.Where(Item => Item.IsBuyBack == true).ToListAsync();
            return items;
        }
    }
}
