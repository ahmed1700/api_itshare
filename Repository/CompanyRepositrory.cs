using System.Collections.Generic;
using Contracts;
using Entities.Data;
using Entities.Models;
using System.Linq;
using System;

namespace Repository
{
    public class CompanyRepositrory : RepositoryBase<Company> , ICompanyRepository
    {
        public CompanyRepositrory(RepositryContext _repositryContext) : base(_repositryContext)
        {

        }

        public IEnumerable<Company> GetCompanies(bool trackChanges) => 
            FindAll(trackChanges).OrderBy(c => c.Name).ToList();

        public Company GetCompany(Guid companyId, bool trackChanges) =>
            FindByCondtion(c => c.Id.Equals(companyId),trackChanges).SingleOrDefault();

    }
}
