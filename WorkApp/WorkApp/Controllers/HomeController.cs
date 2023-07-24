using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using WorkApp.Helpers;
using WorkApp.Models;
using WorkApp.Services.Implements;
using WorkApp.Services.Interfaces;

namespace WorkApp.Controllers;
public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        List<Employee> employees = new List<Employee>();
        DataTable dt = await SqlHelper.SelectAsync("Select * from Employees");
        foreach (DataRow item in dt.Rows)
        {
            employees.Add(new Employee
            {
                Id = (int)item["Id"],
                Name = (string)item["Name"],
                Surname = (string)item["Surname"],
                FatherName = (string)item["FatherName"],
                Salary = (int)item["Salary"], 
                PositionId = (int)item["PositionId"],
            });
        }
        return View(employees);
    }
    [HttpPost]

    public async Task<IActionResult> Employee(string name, string surname, string FatherName, int Salary, int PositionId)
    {
        IEmployeeService service = new EmployeeService();
        await service.AddAsync(new Employee
        {
            Name = name,
            Surname = surname,
            FatherName = FatherName,
            Salary = Salary,
            PositionId = PositionId,
           
        });
        return RedirectToAction(nameof(EmployeeGetAll));
    }
    public async Task<IActionResult> EmployeeGetAll()
    {
        IEmployeeService service = new EmployeeService();
        return Json(await service.GetAllAsync());
    }
    public async Task<IActionResult> EmployeeGetById(int id)
    {
        IEmployeeService service = new EmployeeService();
        return Json(await service.GetByIdAsync(id));
    }
    public async Task<IActionResult> EmployeeDelete(int id)
    {
        IEmployeeService service = new EmployeeService();
        if (await service.Delete(id) > 0)
        {
            return Ok();
        }
        return NotFound();
    }

}

