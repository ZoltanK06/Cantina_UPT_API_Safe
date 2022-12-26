using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.Core.ProjectAggregate;

namespace CantinaUPT_API.Core.Interfaces;
public interface IMealService
{
  Task<Meal> GetMeal(int id);
  Task<List<Meal>> GetAllMeals();
  Task<List<Meal>> GetMealsByIds(List<int> mealIds);
  Task DeleteMeal(int id);
  Task AddMeal(Meal meal);
  Task UpdateMeal(int id, Meal meal);
}
