using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TWTask.Dtos;
using TWTask.Models.Repositories;
using X.PagedList;

namespace TWTask.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

        }

        [HttpGet]
        public async Task<IActionResult> Index(int? page)
        {
            var records = await _employeeRepository.GetAllEmployeeAsync(page);
            return View (records.ToPagedList(page ?? 1, 2));
            
        }

        [HttpPost]
        public async Task Create(EmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeRepository.Add(employeeDto);
                    RedirectToAction("Index", "Employee");
                }
                catch (Exception ex)
                {
                    throw;
                }

            }

        }
        [HttpPost]
        public async Task<IActionResult> Update(EmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeRepository.Update( employeeDto);
                    return RedirectToAction("Index", "Employee");
                }
                catch (Exception ex)
                {

                    throw;
                }

            }
            return Ok("Index");

        }
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var getEmployeeById = await _employeeRepository.GetById(id);
            return Ok(getEmployeeById);
        }
        [HttpPost]
        public IActionResult DeleteEmployee(EmployeeDto employeeDto)
        {
            try
            {
                _employeeRepository.Delete(employeeDto);
                return RedirectToAction("Index", "Employee");
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
