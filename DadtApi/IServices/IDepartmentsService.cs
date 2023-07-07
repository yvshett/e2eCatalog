using DadtApi.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DadtApi.IServices
{
    public interface IDepartmentsService
    {
        public Task<List<DepartmentView>> GetDepartmentLevel3();
        public Task<List<DepartmentView>> GetDepartmentLevel4(string orgLevel3);
        public Task<List<DepartmentView>> GetDepartmentLevel5(string orgLevel3, string orgLevel4);
        public Task<List<DepartmentView>> GetDepartmentLevel6(string orgLevel3, string orgLevel4, string orgLevel5);
    }
}
