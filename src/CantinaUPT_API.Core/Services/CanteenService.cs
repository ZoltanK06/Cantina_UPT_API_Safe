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
public class CanteenService : ICanteenService
{
  private readonly IReadRepository<Canteen> _readRepository;
  private readonly IRepository<Canteen> _repository;
  private readonly IMealService _mealService;

  public CanteenService(IReadRepository<Canteen> readRepository, IRepository<Canteen> repository, IMealService mealService)
  {
    _readRepository = readRepository;
    _repository = repository;
    _mealService = mealService;
  }

  public async Task<List<Canteen>> GetEveryCanteensDetails()
  {
    return await _readRepository.ListAsync();
  }

  public async Task<Canteen> GetMealsOfCanteen(int canteenId)
  {
    var specification = new CanteenWithMeals(canteenId);
    return await _readRepository.GetBySpecAsync(specification);
  }

  public async Task<Canteen> GetMenusOfCanteen(int canteenId)
  {
    var specification = new CanteenWithMenus(canteenId);
    return await _readRepository.GetBySpecAsync(specification);
  }

  public async Task AddCanteen(Canteen canteen)
  {
     await _repository.AddAsync(canteen);
    await _repository.SaveChangesAsync();
  }

  public async Task AssignMealToCanteen(int canteenId, Meal meal)
  {
    var canteen = await _readRepository.GetByIdAsync(canteenId);
    if(canteen == null)
    {
      throw new Exception();
    }
    canteen.Meals ??= new List<Meal>();
    canteen.Meals.Add(meal);
    await _repository.SaveChangesAsync();
  }

  public async Task AssignMealsToCanteen(int canteenId, List<Meal> meals)
  {
    var canteen = await _readRepository.GetByIdAsync(canteenId);
    if (canteen == null)
    {
      throw new Exception();
    }
    canteen.Meals ??= new List<Meal>();
    canteen.Meals.AddRange(meals.AsEnumerable());
    await _repository.SaveChangesAsync();
  }

  public async Task AssignMealsByIdToCanteen(int canteenId, List<int> mealIds)
  {
    var canteen = await _readRepository.GetByIdAsync(canteenId);
    var meals = await _mealService.GetMealsByIds(mealIds);
    if (canteen == null)
    {
      throw new Exception();
    }
    canteen.Meals ??= new List<Meal>();
    canteen.Meals.AddRange(meals);
    await _repository.SaveChangesAsync();
  }

  public async Task DeleteCanteen(int canteenId)
  {
    var canteen = await _readRepository.GetByIdAsync(canteenId);
    await _repository.DeleteAsync(canteen);
    await _repository.SaveChangesAsync();
  }

  public async Task UpdateCanteenDetails(int id, Canteen canteen)
  {
    var oldCanteen = await _readRepository.GetByIdAsync(id);
    if (oldCanteen == null)
    {
      throw new Exception();
    }

    oldCanteen.PictureURL = canteen.PictureURL;
    oldCanteen.Location = canteen.Location;
    oldCanteen.Name = canteen.Name;

    await _repository.UpdateAsync(oldCanteen);
    await _repository.SaveChangesAsync();
  }
}
