using AnyAscii;
using AutoMapper;
using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess;
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.ViewModel.InvoiceViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.StaffViewModel;
using JewelleryShop.DataAccess.Utils;
using Microsoft.Extensions.Configuration;

namespace JewelleryShop.Business.Service
{
    public class StaffService : IStaffService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StaffService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }
        private string RemoveDiacritics(string text)
        {

            return text.Transliterate();
        }
        private string GenerateStaffId(string name, DateTime creationDate)
        {
            name = RemoveDiacritics(name);
            var initials = string.Join("", name.Split(' ').Take(3).Select(x => x[0]).ToArray()).ToUpper();
            var formattedDate = creationDate.ToString("ddMMyyHHmmss");
            return $"{initials}{formattedDate}";
        }

        public async Task<StaffCommonDTO> AddEmployeeAsync(StaffRegisterDTO employee)
        {
            var staffId = GenerateStaffId(employee.FullName, DateTime.Now);

            staff isDuplicate = await _unitOfWork.StaffRepository.GetByIdAsync(staffId);
            if (isDuplicate != null) throw new Exception("Duplicate StaffID!");

            employee.PasswordHash = StringUtils.HashPassword(employee.PasswordHash);
            var emp = _mapper.Map<staff>(employee);
            emp.StaffId = staffId;
            await _unitOfWork.StaffRepository.AddAsync(emp);
            await _unitOfWork.SaveChangeAsync();

            return _mapper.Map<StaffCommonDTO>(emp);
        }

        public void DisableAccount(staff staff)
        {
            staff.Status = "Inactive";
            _unitOfWork.StaffRepository.Update(staff);
            _unitOfWork.SaveChangeAsync();
        }

        public async Task<string> LoginAsync(StaffLoginDTO employee)
        {
            var user = await _unitOfWork.StaffRepository.CheckLoginCredentials(employee.UsernameOrEmail, employee.Password);
            if (user != null)
            {
                string jwtKey = _configuration.GetValue<string>("Jwt:SecretKey");
                double expirationTime = _configuration.GetValue<double>("Jwt:ExpiryTimeMinutes");

                return user.GenerateJsonWebToken(jwtKey, DateTime.UtcNow, expiration: expirationTime);
            }
            return null;
        }

        public async Task<List<StaffCommonDTO>> GetAllStaff()
        {
            var staff = await _unitOfWork.StaffRepository.GetAllAsync();
            return _mapper.Map<List<StaffCommonDTO>>(staff);
        }

        public async Task<StaffCommonDTO> GetStaffById(string id)
        {
            var staff = await _unitOfWork.StaffRepository.GetByIdAsync(id);
            return _mapper.Map<StaffCommonDTO>(staff);
        }

        public async Task<StaffCommonDTO> UpdateEmployeeAsync(string id, StaffRegisterDTO employeeDTO)
        {
            var employee = await _unitOfWork.StaffRepository.GetByIdAsync(id);
            if (employee == null)
            {
                throw new Exception("Employee not found.");
            }
            employee = _mapper.Map<StaffRegisterDTO, staff>(employeeDTO, employee);

            await _unitOfWork.StaffRepository.UpdateAsync(id, employee);
            await _unitOfWork.SaveChangeAsync();

            return _mapper.Map<StaffCommonDTO>(employee);
        }
        public async Task DeleteEmployeeAsync(string id)
        {
            var employee = await _unitOfWork.StaffRepository.GetByIdAsync(id);
            if (employee != null)
            {
                await _unitOfWork.StaffRepository.DeleteAsync(id);
                await _unitOfWork.SaveChangeAsync();
            }
            else
            {
                throw new ArgumentException("No employee found with the provided ID.");
            }
        }
    }
}
