using JewelleryShop.DataAccess.Models.ViewModel.CollectionViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service.Interface
{
    public interface ICollectionService
    {
        public Task<List<CollectionCommonDTO>> GetAllCollection();
        public Task<CollectionCommonDTO> GetCollectionById(string id);
        public Task<CollectionCommonDTO> UpdateCollectionAsync(string id, CollectionInputDTO collectionDTO);
        public Task<CollectionCommonDTO> AddCollection(CollectionInputDTO collection);
        public Task DeleteCollectionAsync(string id);
    }
}
