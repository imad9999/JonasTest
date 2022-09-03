using AutoMapper;
using BusinessLayer.Model.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly ILog _log;


        public EmployeeController(IEmployeeService employeeService, IMapper mapper, ILog log)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _log = log;
        }
        public EmployeeController()
        {

        }
        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            try
            {
                var items = await _employeeService.GetAllEmployeesAsync();
                return _mapper.Map<IEnumerable<EmployeeDto>>(items);
            }
            catch (Exception e)
            {
                _log.Debug(e.ToString());
                throw e;
            }
        }

        public async Task<EmployeeDto> Get(string employeeCode)
        {
            try
            {
                var item = await _employeeService.GetEmployeeByCodeAsync(employeeCode);
                return _mapper.Map<EmployeeDto>(item);
            }
            catch (Exception e)
            {
                _log.Debug(e.ToString());
                throw e;
            }
        }

        public async Task<string> Post([FromBody] string value)
        {
            try
            {
                var response = await _employeeService.SaveEmployeeAsync(value);
                return response;
            }
            catch (Exception e)
            {
                _log.Debug(e.ToString());
                throw e;
            }
        }

        public async Task<string> Put(int id, [FromBody] string value)
        {
            try
            {
                var response = await _employeeService.SaveEmployeeAsync(value);
                return response;
            }
            catch (Exception e)
            {
                _log.Debug(e.ToString());
                throw e;
            }
        }
    }
}
