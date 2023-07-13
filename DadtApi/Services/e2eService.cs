using DadtApi.Context;
using DadtApi.IServices;
using DadtApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DadtApi.Services
{
    public class e2eService : Ie2eService
    {
        dbContext _e2eDbcontext;
        public e2eService(dbContext e2eDbContext)
        {
            _e2eDbcontext = e2eDbContext;
        }
        public dynamic GetCategoriesWithSubcategories()
        {
            var menu = _e2eDbcontext.Categories
              .Include(c => c.SubCategories)
              .ThenInclude(s => s.Items)
              .ThenInclude(i => i.ItemAttributes)
              .Select(c => new
              {
                  Category = c.CategoryName,
                  Description = c.Description,
                  SubCategory = c.SubCategories.Select(s => new
                  {
                      SubCategory = s.SubCategoryName,
                      IsActive = s.IsActive,
                      Assets = s.Items.Select(i => new
                      {
                          Name = i.ItemName,
                          Image = i.ItemImageLink,
                          ItemCode = i.ItemCode,
                          Attributes = i.ItemAttributes.OrderBy(a => a.AttributeName)
                          .Select(a => new
                          {
                              Key = a.AttributeName,
                              Value = a.AttributeValue
                          }).ToList()
                      }).ToList()
                  }).ToList()
              }).ToList();

            return menu;
     
        }

        public dynamic GetCategory()
        {
            List<Models.Category> menu = null;
            try
            {
                menu = _e2eDbcontext.Categories.ToList();
            }
            catch (Exception ex)
            {

            }
            
              

            return menu;

        }

    }
}
