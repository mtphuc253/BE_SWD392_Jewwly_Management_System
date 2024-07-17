using AnyAscii;
using AutoMapper;
using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess;
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.ViewModel.CustomerViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyAscii;

namespace JewelleryShop.Business.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CustomerCommonDTO>> GetAllAsync()
        {
            return _mapper.Map<List<CustomerCommonDTO>>(await _unitOfWork.CustomerRepository.GetAllAsync());
        }
        public async Task<CustomerCommonDTO> GetByIDAsync(string id)
        {
            var entity = await _unitOfWork.CustomerRepository.GetByIDAsync(id);
            return entity == null ? null : _mapper.Map<CustomerCommonDTO>(entity);
        }

        public async Task<CustomerCommonDTO> GetByEmailAsync(string email)
        {
            var entity = await _unitOfWork.CustomerRepository.GetByEmailAsync(email);
            return entity == null ? null : _mapper.Map<CustomerCommonDTO>(entity);
        }

        public async Task<CustomerCommonDTO> GetByPhoneNumberAsync(string phoneNumber)
        {
            var entity = await _unitOfWork.CustomerRepository.GetByPhoneNumberAsync(phoneNumber);
            return entity == null ? null : _mapper.Map<CustomerCommonDTO>(entity);
        }

        private string RemoveDiacritics(string text)
        {

            return text.Transliterate();
        }
        private string GenerateCustomerId(string name, DateTime creationDate)
        {
            name = RemoveDiacritics(name);
            var initials = string.Join("", name.Split(' ').Take(3).Select(x => x[0]).ToArray()).ToUpper();
            var formattedDate = creationDate.ToString("ddMMyyHHmmss");
            return $"{initials}{formattedDate}";
        }
        public async Task<CustomerCommonDTO> CreateCustomerAsync(CustomerInputDTO customerData)
        {
            var existedEmail = await _unitOfWork.CustomerRepository.GetByEmailAsync(customerData.Email);
            var existedPhoneNum = await _unitOfWork.CustomerRepository.GetByPhoneNumberAsync(customerData.PhoneNumber);
            if (existedPhoneNum != null &&  existedEmail != null)
                throw new Exception("Email and PhoneNumber already exists");
            if (existedEmail != null)
                throw new Exception("Email already exists");
            if (existedPhoneNum != null)
                throw new Exception("Phone number already exists");
            var customerID = GenerateCustomerId(customerData.CustomerName, DateTime.Now);
            var isDuplicate = await _unitOfWork.CustomerRepository.GetByIDAsync(customerID);
            if (isDuplicate != null) { throw new Exception("Duplicate Customer ID!"); }
            var customerEntity = _mapper.Map<Customer>(customerData);
            customerEntity.Id = customerID;
            await _unitOfWork.CustomerRepository.AddAsync(customerEntity);
            await _unitOfWork.SaveChangeAsync();

            return _mapper.Map<CustomerCommonDTO>(customerEntity);
        }

        public async Task<CustomerInputDTO> UpdateCustomerAsync(string id, CustomerInputDTO newCustomerData)
        {
            var allCustomer = await _unitOfWork.CustomerRepository.GetAllAsync();
            var CurrEmail = allCustomer
                .Where(c => c.Email == newCustomerData.Email && c.Id != id).ToList();
            var CurrPhoneNumber = allCustomer
                .Where(c => c.PhoneNumber == newCustomerData.PhoneNumber && c.Id != id).ToList();
            if (CurrEmail.Any() && CurrPhoneNumber.Any())
                throw new Exception("Email and PhoneNumber already exists");

            if (CurrPhoneNumber.Any())
                throw new Exception("PhoneNumber already exists");

            if(CurrEmail.Any())
                throw new Exception("Email already exists");

            var existingCustomer = await _unitOfWork.CustomerRepository.GetByIDAsync(id);

            if (existingCustomer == null)
                return null;

            _mapper.Map(newCustomerData, existingCustomer);

            _unitOfWork.CustomerRepository.Update(existingCustomer);
            await _unitOfWork.SaveChangeAsync();

            return _mapper.Map<CustomerInputDTO>(existingCustomer);
        }
    }
}

