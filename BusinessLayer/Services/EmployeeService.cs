using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EmployeeInfo>> GetAllEmployeesAsync()
        {
            try
            {
                var res = await _employeeRepository.GetAll();
                return _mapper.Map<IEnumerable<EmployeeInfo>>(res);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<EmployeeInfo> GetEmployeeByCodeAsync(string employeeCode)
        {
            try
            {
                var result = await _employeeRepository.GetByCode(employeeCode);
                return _mapper.Map<EmployeeInfo>(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> SaveEmployeeAsync(string value)
        {
            try
            {
                var deserializedCompany = JsonConvert.DeserializeObject<Employee>(value);
                var repositoryResponse = await _employeeRepository.SaveEmployeeAsync(deserializedCompany);
                if (repositoryResponse)
                {
                    return "Employee details saved successfully";
                }
                return "Error Occured: Failed to save Employee details";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
