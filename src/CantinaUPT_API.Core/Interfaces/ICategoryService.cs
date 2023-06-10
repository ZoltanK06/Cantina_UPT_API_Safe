using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.Core.ProjectAggregate;

namespace CantinaUPT_API.Core.Interfaces;
public interface ICategoryService
{
  Task<Category> GetCategoryById(int categoryId);
  Task<List<Category>> GetAllCategories();
  Task<List<CategoryWithPictures>> GetAllCategoriesWithPictures();
}
