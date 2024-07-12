using DAL.Interfaces;
using TT_Auth.Models.ENUMS;

namespace TT_Auth.Services
{
    public class EmployeesServices
    {
        private readonly iBaseRepository<EmployeesServices> _employeeRepository;
        public EmployeesServices(iBaseRepository<EmployeesServices> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeesServices> SortBy(SortOptions sort)
        {


            throw new NotImplementedException();
        }
        
    }
}
