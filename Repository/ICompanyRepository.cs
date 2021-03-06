using Health.Entity.Entity;
using Health.Entity.Wrappers;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        IEnumerable<Company> GetPopularCompanies(int count);
        IEnumerable<Company> GetAllCompany();
        bool companyAlreadyexist(string name);

        IEnumerable<Company> GetCompanyByPage(PagedResponse pagedResponse);


    }
}
