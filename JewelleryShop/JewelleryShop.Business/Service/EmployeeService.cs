using AutoMapper;
using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess;
using JewelleryShop.DataAccess.Models.ViewModel.EmployeeViewModel;
using JewelleryShop.DataAccess.Utils;
using Microsoft.Extensions.Configuration;

namespace JewelleryShop.Business.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService (IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<string> LoginAsync(EmployeeLoginDTO employee)
        {
            var user = await _unitOfWork.EmployeeRepository.CheckLoginCredentials(employee.UsernameOrEmail, employee.Password);
            if (user != null)
            {
                return user.GenerateJsonWebToken(_configuration.GetValue<string>("Jwt:SecretKey"), DateTime.UtcNow);
            }
            return null;
        }
    }
}
