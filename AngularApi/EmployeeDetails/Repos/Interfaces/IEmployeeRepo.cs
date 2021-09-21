using EmployeeDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Interfaces.Repos
{
    public interface IEmployeeRepo
    {
        bool SaveChanges();

        IEnumerable<EmployeeModel> GetAll();

        EmployeeModel GetById(int id);

        void Create(EmployeeModel employee);

        void Update(EmployeeModel employee);

        void Delete(EmployeeModel employee);
    }
}
