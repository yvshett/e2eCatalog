using DadtApi.CommonUtility;
using DadtApi.Context;
using DadtApi.DomainModels;
using DadtApi.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DadtApi.Services
{
    public class DepartmentsService : IDepartmentsService
    {
        private readonly dbContext _context;
        private readonly ILog _log;

        public DepartmentsService(dbContext context, ILog log)
        {
            _context = context;
            _log = log;
        }

        /// <summary>
        /// Gets level 3 active departments from Department table
        /// </summary>
        /// <returns>List of level 3 departments</returns>
        public async Task<List<DepartmentView>> GetDepartmentLevel3()
        {
            List<DepartmentView> orgLevel3 = new List<DepartmentView>();
            string startTime = DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss.fffZ");
            string stepName = MethodBase.GetCurrentMethod().ReflectedType.FullName;

            try
            {
                orgLevel3 = await _context.Departments.Where(o => o.ActiveInd.Equals("Y")).Select(o => new DepartmentView
                {
                    DepartmentLevel3Cd = o.DepartmentLevel3Cd,
                    DepartmentLevel3Nm = o.DepartmentLevel3Nm
                }).Distinct().OrderBy(x => x.DepartmentLevel3Nm).ToListAsync();

                orgLevel3.RemoveAll(item => (item.DepartmentLevel3Nm == "NULL" || item.DepartmentLevel3Nm == null)
                                    || (item.DepartmentLevel3Cd == "NULL" || item.DepartmentLevel3Cd == null));
            }
            catch (Exception ex)
            {
                _log.LogEntry(stepName, "Error : " + ex, CommonUtility.Constants.STR_LOG_TYPE_ERROR, startTime, DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss.fffZ"));
            }

            return orgLevel3;
        }

        /// <summary>
        /// Gets level 4 active departments based on selected level 3 value from Department table
        /// </summary>
        /// <returns>List of level 4 departments</returns>
        public async Task<List<DepartmentView>> GetDepartmentLevel4(string orgLevel3)
        {
            List<DepartmentView> orgLevel4 = new List<DepartmentView>();
            string startTime = DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss.fffZ");
            string stepName = MethodBase.GetCurrentMethod().ReflectedType.FullName;

            try
            {
                orgLevel4 = await _context.Departments.Where(o => o.DepartmentLevel3Cd == orgLevel3 && o.ActiveInd.Equals("Y")).Select(o => new DepartmentView
                {
                    DepartmentLevel4Cd = o.DepartmentLevel4Cd,
                    DepartmentLevel4Nm = o.DepartmentLevel4Nm
                }).Distinct().OrderBy(x => x.DepartmentLevel4Nm).ToListAsync();

                orgLevel4.RemoveAll(item => (item.DepartmentLevel4Nm == "NULL" || item.DepartmentLevel4Nm == null)
                                    || (item.DepartmentLevel4Cd == "NULL" || item.DepartmentLevel4Cd == null));
            }
            catch (Exception ex)
            {
                _log.LogEntry(stepName, "Error : " + ex, CommonUtility.Constants.STR_LOG_TYPE_ERROR, startTime, DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss.fffZ"));
            }

            return orgLevel4;
        }

        /// <summary>
        /// Gets level 5 active departments based on selected level 3, level 4 values from Department table
        /// </summary>
        /// <returns>List of level 5 departments</returns>
        public async Task<List<DepartmentView>> GetDepartmentLevel5(string orgLevel3, string orgLevel4)
        {
            List<DepartmentView> orgLevel5 = new List<DepartmentView>();
            string startTime = DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss.fffZ");
            string stepName = MethodBase.GetCurrentMethod().ReflectedType.FullName;

            try
            {
                orgLevel5 = await _context.Departments.Where(o => o.DepartmentLevel3Cd == orgLevel3 && o.DepartmentLevel4Cd == orgLevel4
                            && o.ActiveInd.Equals("Y")).Select(o => new DepartmentView
                            {
                                DepartmentLevel5Cd = o.DepartmentLevel5Cd,
                                DepartmentLevel5Nm = o.DepartmentLevel5Nm
                            }).Distinct().OrderBy(x => x.DepartmentLevel5Nm).ToListAsync();

                orgLevel5.RemoveAll(item => (item.DepartmentLevel5Nm == "NULL" || item.DepartmentLevel5Nm == null)
                                    || (item.DepartmentLevel5Cd == "NULL" || item.DepartmentLevel5Cd == null));
            }
            catch (Exception ex)
            {
                _log.LogEntry(stepName, "Error : " + ex, CommonUtility.Constants.STR_LOG_TYPE_ERROR, startTime, DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss.fffZ"));
            }

            return orgLevel5;
        }

        /// <summary>
        /// Gets level 5 active departments based on selected level 3, level 4, level 5 values from Department table
        /// </summary>
        /// <returns>List of level 6 departments</returns>
        public async Task<List<DepartmentView>> GetDepartmentLevel6(string orgLevel3, string orgLevel4, string orgLevel5)
        {
            List<DepartmentView> orgLevel6 = new List<DepartmentView>();
            string startTime = DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss.fffZ");
            string stepName = MethodBase.GetCurrentMethod().ReflectedType.FullName;

            try
            {
                orgLevel6 = await _context.Departments.Where(o => o.DepartmentLevel3Cd == orgLevel3 && o.DepartmentLevel4Cd == orgLevel4
                            && o.DepartmentLevel5Cd == orgLevel5 && o.ActiveInd.Equals("Y")).Select(o => new DepartmentView
                            {
                                DepartmentLevel6Cd = o.DepartmentLevel6Cd,
                                DepartmentLevel6Nm = o.DepartmentLevel6Nm
                            }).Distinct().OrderBy(x => x.DepartmentLevel6Nm).ToListAsync();

                orgLevel6.RemoveAll(item => (item.DepartmentLevel6Nm == "NULL" || item.DepartmentLevel6Nm == null)
                                    || (item.DepartmentLevel6Cd == "NULL" || item.DepartmentLevel6Cd == null));
            }
            catch (Exception ex)
            {
                _log.LogEntry(stepName, "Error : " + ex, CommonUtility.Constants.STR_LOG_TYPE_ERROR, startTime, DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss.fffZ"));
            }

            return orgLevel6;
        }
    }
}
