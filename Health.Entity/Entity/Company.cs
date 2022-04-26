using Health.Entity.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health.Entity.Entity
{
    public class Company : BaseEntity
    {
        public string? companyName { get; set; }
        public string? companyUrl { get; set; }
        public string?  description { get; set; }


    }
}
