using BusinessLayer.Model.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CompanyInfo>> GetAllCompaniesAsync()
        {
            var res = await _companyRepository.GetAll();
            return _mapper.Map<IEnumerable<CompanyInfo>>(res);
        }

        public async Task<CompanyInfo> GetCompanyByCodeAsync(string companyCode)
        {
            var result = await _companyRepository.GetByCode(companyCode);
            return _mapper.Map<CompanyInfo>(result);
        }

        public async Task<string> SaveCompanyAsync(string value)
        {
            try
            {
                var deserializedCompany = JsonConvert.DeserializeObject<Company>(value);
                var repositoryResponse = await _companyRepository.SaveCompanyAsync(deserializedCompany);
                if (repositoryResponse)
                {
                    return "Company details saved successfully";
                }
                return "Error Occured: Failed to save compnay details";
            }
            catch(Exception e)
            {
                return e.ToString();
            }
        }

        public async Task<string> DeleteCompanyAsync(int id)
        {
            var repositoryResponse = await _companyRepository.DeleteCompanyAsync(id);
            return repositoryResponse.ToString();
        }
    }
}
