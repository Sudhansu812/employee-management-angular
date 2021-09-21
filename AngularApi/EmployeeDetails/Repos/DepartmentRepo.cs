using EmployeeDetails.Models;
using EmployeeDetails.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Repos
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly DepartmentContext _context;

        public DepartmentRepo(DepartmentContext context)
        {
            _context = context;
        }

        public void Create(DepartmentModel department)
        {
            if (department == null)
            {
                throw new ArgumentNullException();
            }
            _context.Departments.AddAsync(department);
        }

        public void Delete(DepartmentModel department)
        {
            if (department == null)
            {
                throw new ArgumentNullException();
            }
            _context.Departments.Remove(department);
        }

        public IEnumerable<DepartmentModel> GetAll()
        {
            return _context.Departments.ToList();
        }

        public DepartmentModel GetById(int id)
        {
            return _context.Departments.FirstOrDefault(department => department.DepartmentId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(DepartmentModel department)
        {
            // nothing
        }
    }
}
