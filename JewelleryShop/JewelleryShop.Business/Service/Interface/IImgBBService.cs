using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.ViewModel.ImgBBViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service.Interface
{
    public interface IImgBBService
    {
        public Task<ImageUploadResponse> UploadImageAsync(byte[] imageBytes);
    }
}
