using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private ILoggerManager _logger;
        private readonly IRepositroryManager _repositrory;
        private readonly IMapper _mapper;
        public EmployeeController(ILoggerManager logger, IRepositroryManager repositrory, IMapper mapper)
        {
            this._logger = logger;
            this._repositrory = repositrory;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEmployeesForCompany(Guid companyId)
        {
            var company = _repositrory.Company.GetCompany(companyId, trackChanges: false);
            if (company == null)
            {
                _logger.LogInfo($"Company Wiht Id : {companyId} doesn't exist in the database");
                return NotFound();
            }
            var employees = _repositrory.Employee.GetEmployees(companyId, trackChanges: false);
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(employeesDto);
        }


        [HttpGet("{id}")]
        public IActionResult GetEmployeeForCompany(Guid companyId , Guid id)
        {
            var company = _repositrory.Company.GetCompany(companyId, trackChanges: false);
            if (company == null)
            {
                _logger.LogInfo($"Company Wiht Id : {companyId} doesn't exist in the database");
                return NotFound();
            }
            var employee = _repositrory.Employee.GetEmployee(companyId, id, trackChanges: false);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }
    }
}