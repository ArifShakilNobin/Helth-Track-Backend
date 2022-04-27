using Health.DataService.Data;
using Health.Entity.Entity;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {
        }

        public bool companyAlreadyexist(string name)
        {
            return _context.Companies.Any(c => c.companyName == name);
        }

        public IEnumerable<Company> GetAllCompany()
        {
            return _context.Companies.Distinct().ToList();
        }

        public IEnumerable<Company> GetPopularCompanies(int count)
        {
            return _context.Companies.OrderByDescending(d => d.companyName).Take(count).ToList();
        }
    }
}
