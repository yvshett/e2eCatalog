using Microsoft.AspNetCore.Mvc;

namespace DadtApi.IServices
{
    public interface Ie2eService
    {
       public dynamic GetCategoriesWithSubcategories();
        public dynamic GetCategory();
    }
}
