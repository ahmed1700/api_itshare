using System;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Collections.Generic;
using Entities.DataTransferObjects;

namespace CompanyEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private ILoggerManager _logger;
        private readonly IRepositroryManager _repositrory;
        private readonly IMapper _mapper;
        public CompaniesController(ILoggerManager logger, IRepositroryManager repositrory , IMapper mapper)
        {
            this._logger = logger;
            this._repositrory = repositrory;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
                var companies = _repositrory.Company.GetCompanies(trackChanges: false);
                var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
                return Ok(companiesDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetCompany(Guid id)
        {
            var comapny = _repositrory.Company.GetCompany(id, trackChanges: false);
            if (comapny==null)
            {
                _logger.LogInfo($"Company Wiht Id : {id} doesn't exist in the database");
                return NotFound();
            }
            else
            {
                var companyDto = _mapper.Map<CompanyDto>(comapny);
                return Ok(companyDto);
            }
        }
    }
}