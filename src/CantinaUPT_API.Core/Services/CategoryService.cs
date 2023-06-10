using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.Core.Interfaces;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.Core.ProjectAggregate.Specifications;
using CantinaUPT_API.SharedKernel.Interfaces;

namespace CantinaUPT_API.Core.Services;
public class CategoryService: ICategoryService
{
  public readonly IReadRepository<Category> _categoryRepo;
  public readonly IReadRepository<CategoryPictures> _picturesRepo;

  public CategoryService(IReadRepository<Category> categoryRepo, IReadRepository<CategoryPictures> picturesRepo)
  {
    _categoryRepo = categoryRepo;
    _picturesRepo = picturesRepo;
  }

  public async Task<Category> GetCategoryById(int categoryId)
  {
    return await _categoryRepo.GetByIdAsync(categoryId);
  }

  public async Task<List<Category>> GetAllCategories()
  {
    return await _categoryRepo.ListAsync();
  }

  public async Task<List<CategoryWithPictures>> GetAllCategoriesWithPictures()
  {
    var categories = await _categoryRepo.ListAsync();
    var pictures = await _picturesRepo.ListAsync();
    var categoriesWithPictures = new List<CategoryWithPictures>();

    categories.ForEach(category =>
    {
      var categoryWithPic = new CategoryWithPictures
      {
        Id = category.Id,
        CategoryName = category.CategoryName,
        PictureURL = pictures.Find(pic => pic.Id == category.Id).PictureURL
      };

      categoriesWithPictures.Add(categoryWithPic);
    });

    return categoriesWithPictures;
  }
}
