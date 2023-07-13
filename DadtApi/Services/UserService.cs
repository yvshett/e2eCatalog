using DadtApi.Context;
using System;
using System.Linq;
using System.Threading.Tasks;
using DadtApi.IServices;
using Microsoft.EntityFrameworkCore;
using DadtApi.DomainModels;
using DadtApi.CommonUtility;
using System.Reflection;

namespace DadtApi.Services
{
    public class UserService : IUserService
    {
        private readonly dbContext _context;
        private readonly ILog _log;
        public UserService(dbContext context, ILog log)
        {
            _context = context;
            _log = log;
        }

       
    }
}
