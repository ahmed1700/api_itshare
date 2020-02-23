using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetCompanies(bool trackChanges);

        Company  GetCompany(Guid companyId,  bool trackChanges);
    }
}
