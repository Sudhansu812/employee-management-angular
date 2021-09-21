using EmployeeDetails.Interfaces.Repos;
using EmployeeDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Repos
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EmployeeContext _context;

        public EmployeeRepo(EmployeeContext context)
        {
            _context = context;
        }

        public void Create(EmployeeModel employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException();
            }
            _context.Employees.AddAsync(employee);
        }

        public void Delete(EmployeeModel employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException();
            }
            _context.Employees.Remove(employee);
        }

        public IEnumerable<EmployeeModel> GetAll()
        {
            return _context.Employees.ToList();
        }

        public EmployeeModel GetById(int id)
        {
            return _context.Employees.FirstOrDefault(employee => employee.EmployeeId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(EmployeeModel employee)
        {
            // nothing
        }
    }
}
