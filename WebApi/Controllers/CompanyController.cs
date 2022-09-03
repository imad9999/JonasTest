using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using log4net;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private readonly ILog _log;

        public CompanyController(ICompanyService companyService, IMapper mapper, ILog log)
        {
            _companyService = companyService;
            _mapper = mapper;
            _log = log;
        }
        public CompanyController()
        {

        }
        // GET api/<controller>
        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            try
            {
                var items = await _companyService.GetAllCompaniesAsync();
                return _mapper.Map<IEnumerable<CompanyDto>>(items);
            }
            catch (Exception e)
            {
                _log.Debug(e.ToString());
                throw new Exception("unknown error occured");
            }
        }

        // GET api/<controller>/5
        public async Task<CompanyDto> Get(string companyCode)
        {
            try
            {
                var item = await _companyService.GetCompanyByCodeAsync(companyCode);
                return _mapper.Map<CompanyDto>(item);
            }
            catch (Exception e)
            {
                _log.Debug(e.ToString());
                throw new Exception("unknown error occured");
            }
        }

        // POST api/<controller>
        public async Task<string> Post([FromBody] string value)
        {
            try
            {
                var response = await _companyService.SaveCompanyAsync(value);
                return response;
            }
            catch (Exception e)
            {
                _log.Debug(e.ToString());
                throw new Exception("unknown error occured");
            }
        }

        // PUT api/<controller>/5
        public async Task<string> Put(int id, [FromBody] string value)
        {
            try
            {
                var response = await _companyService.SaveCompanyAsync(value);
                return response;
            }
            catch (Exception e)
            {
                _log.Debug(e.ToString());
                throw new Exception("unknown error occured");
            }
        }

        // DELETE api/<controller>/5
        public async Task<string> Delete(int id)
        {
            try
            {
                var response = await _companyService.DeleteCompanyAsync(id);
                return response;
            }
            catch (Exception e)
            {
                _log.Debug(e.ToString());
                throw new Exception("unknown error occured");
            }
        }
    }
}