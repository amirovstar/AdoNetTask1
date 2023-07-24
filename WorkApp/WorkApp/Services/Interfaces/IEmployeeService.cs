using System;
using WorkApp.Models;

namespace WorkApp.Services.Interfaces
{
	
        public interface IEmployeeService
        {
            public Task<int> AddAsync(Employee music);
            public Task<int> AddAsync(List<Employee> musics);
            public Task<List<Employee>> GetAllAsync();
            public Task<Employee> GetByIdAsync(int id);
            public Task<int> Delete(int id);
            public Task<Employee> Update(int id, Employee employee);
        }
    
}

