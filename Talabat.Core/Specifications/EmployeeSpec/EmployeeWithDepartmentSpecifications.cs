using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications.EmployeeSpec
{
    public class EmployeeWithDepartmentSpecifications : BaseSpecifications<Employee>
    {
        public EmployeeWithDepartmentSpecifications() : base()
        {
            Include.Add(E=> E.Department);
        }

        public EmployeeWithDepartmentSpecifications(int id) : base(E=> E.Id == id)
        {
            Include.Add(E => E.Department);
        }
    }
}
