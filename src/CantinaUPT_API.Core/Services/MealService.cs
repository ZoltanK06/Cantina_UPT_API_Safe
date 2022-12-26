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
public class MealService : IMealService
{
  private readonly IReadRepository<Meal> _readRepository;
  private readonly IRepository<Meal> _repository;

  public MealService(IReadRepository<Meal> readRepository, IRepository<Meal> repository)
  {
    _readRepository = readRepository;
    _repository = repository;
  }


  public async Task<Meal> GetMeal(int id)
  {
    return await _readRepository.GetByIdAsync(id);
  }

  public async Task<List<Meal>> GetAllMeals()
  {
    return await _readRepository.ListAsync();
  }

  public async Task<List<Meal>> GetMealsByIds(List<int> mealIds)
  {
    var specification = new MealsByIdList(mealIds);
    return await _readRepository.ListAsync(specification);
  }

  public async Task DeleteMeal(int id)
  {
    Meal meal = await _readRepository.GetByIdAsync(id);
    await _repository.DeleteAsync(meal);
    await _repository.SaveChangesAsync();
  }

  public async Task AddMeal(Meal meal)
  {
    await _repository.AddAsync(meal);
    await _repository.SaveChangesAsync();
  }

  public async Task UpdateMeal(int id, Meal meal)
  {
    var oldMeal = await _readRepository.GetByIdAsync(id);
    if(oldMeal == null)
    {
      throw new Exception();
    }

    oldMeal.Description = meal.Description;
    oldMeal.Category = meal.Category;
    oldMeal.Portion = meal.Portion;
    oldMeal.Price = meal.Price;
    oldMeal.Name = meal.Name;

    await _repository.UpdateAsync(oldMeal);
    await _repository.SaveChangesAsync(); 
  }


}
