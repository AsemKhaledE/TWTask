using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TWTask.Data;
using TWTask.Dtos;
using X.PagedList;

namespace TWTask.Models.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        TWTaskDbContext _context;
        IMapper _mapper;
        public EmployeeRepository(TWTaskDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<EmployeeDto> Add(EmployeeDto employeeDto)
        {
            try
            {
                var addEmployee = _mapper.Map<EmployeeDto, Employees>(employeeDto);
                _context.Employees.Add(addEmployee);
                await _context.SaveChangesAsync();
                var lastEmpoyee = await _context.Employees.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                if (lastEmpoyee != null)
                {

                    var address = new Address
                    {
                        Description = employeeDto.Description,
                        EmployeeId = lastEmpoyee!.Id
                    };
                    _context.Addresses.Add(address);
                    await _context.SaveChangesAsync();

                }
                return (employeeDto);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Delete(EmployeeDto employeeDto)
        {
            var employee = _context.Employees!.FirstOrDefault(u => u.Id == employeeDto.Id);
            _context.Employees?.Remove(employee!);
            _context.SaveChanges();
        }

        public async Task<List<EmployeeDto>> GetAllEmployeeAsync(int? page)
        {
            var records = await _context.Employees.Include(x => x.Addresses).ToListAsync();

            return _mapper.Map<List<EmployeeDto>>(records);

        }

        public async Task<EmployeeDto> GetById(int id)
        {
            var employee = await _context.Employees.Include(x => x.Addresses).FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> Update(EmployeeDto employeeDto)
        {

            try
            {
                var updateEmployee = _mapper.Map<EmployeeDto, Employees>(employeeDto);
                _context.Employees.Update(updateEmployee);
                await _context.SaveChangesAsync();
                var empoyeeAddress = await _context.Addresses.Where(x => x.EmployeeId == employeeDto.Id).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                if (empoyeeAddress != null)
                {
                    empoyeeAddress.Description = employeeDto.Description;
                    _context.Addresses.Update(empoyeeAddress);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var address = new Address
                    {
                        Description = employeeDto.Description,
                        EmployeeId = employeeDto.Id
                    };
                    _context.Addresses.Add(address);
                    await _context.SaveChangesAsync();
                }
                return (employeeDto);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
