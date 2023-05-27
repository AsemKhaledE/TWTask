using TWTask.Dtos;

namespace TWTask.Models.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeDto>> GetAllEmployeeAsync(int? page);
        //Task<EmployeeDto> GetPaginated(int page, int pageSize);
        Task<EmployeeDto> GetById(int id);
        Task<EmployeeDto> Add(EmployeeDto employeeDto);
        Task<EmployeeDto> Update(EmployeeDto employeeDto);
        void Delete(EmployeeDto employeeDto);
    }
}
