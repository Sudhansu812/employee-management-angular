using EmployeeDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Repos.Interfaces
{
    public interface IDepartmentRepo
    {
        bool SaveChanges();

        IEnumerable<DepartmentModel> GetAll();

        DepartmentModel GetById(int id);

        void Create(DepartmentModel department);

        void Update(DepartmentModel department);

        void Delete(DepartmentModel department);
    }
}
