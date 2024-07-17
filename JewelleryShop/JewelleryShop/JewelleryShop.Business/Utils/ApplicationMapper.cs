using System;

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JewelleryShop.DataAccess.Models;

using JewelleryShop.DataAccess.Models.dto;
using JewelleryShop.DataAccess.Models.ViewModel.CollectionViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.CustomerViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.GemstoneViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.InvoiceViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.ItemImageViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.ItemViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.PromotionViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.ReturnPolicyViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.RewardsProgramViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.StaffShiftViewsModel;
using JewelleryShop.DataAccess.Models.ViewModel.StaffViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.WarrantyViewModel;

namespace JewelleryShop.DataAccess.Utils
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Invoice, InvoiceCommonDTO>().ReverseMap();
            CreateMap<Invoice, InvoiceInputNewDTO>().ReverseMap();
            CreateMap<Warranty, WarrantyCommonDTO>().ReverseMap();

            CreateMap<Invoice, InvoiceInputDTO>().ReverseMap();
            CreateMap<Warranty, WarrantyInputDTO>().ReverseMap();

            CreateMap<Customer, CustomerCommonDTO>().ReverseMap();
            CreateMap<Customer, CustomerInputDTO>().ReverseMap();

            CreateMap<Item, ItemDTO>().ReverseMap();
            CreateMap<Item, ItemCreateDTO>().ReverseMap();
            CreateMap<staff, StaffCommonDTO>().ReverseMap();
            CreateMap<staff, StaffRegisterDTO>().ReverseMap();

            CreateMap<StaffStation, StaffShiftCommonDTO>().ReverseMap();
            CreateMap<StaffStation, StaffShiftInputDTO>().ReverseMap();

            CreateMap<RewardsProgram, RewardsProgramCommonDTO>().ReverseMap();
            CreateMap<RewardsProgram, RewardsProgramInputDTO>().ReverseMap();
            
            CreateMap<Collection, CollectionCommonDTO>().ReverseMap();
            CreateMap<Collection, CollectionInputDTO>().ReverseMap();
            
            CreateMap<Gemstone, GemstoneCommonDTO>().ReverseMap();
            CreateMap<Gemstone, GemstoneInputDTO>().ReverseMap();

            CreateMap<ItemImage, ItemImageCommonDTO>().ReverseMap();
            CreateMap<ItemImage, ItemImageInputDTO>().ReverseMap();

            CreateMap<CustomerPromotion, CustomerPromotionDto>().ReverseMap();

            CreateMap<Discount, DiscountDto>().ReverseMap();

            CreateMap<ReturnPolicy, ReturnPolicyCommonDTO>().ReverseMap();
            CreateMap<ReturnPolicy, ReturnPolicyUpdateDTO>().ReverseMap();
            CreateMap<ReturnPolicy, ReturnPolicyCreateDTO>().ReverseMap();
        }
    }
}
