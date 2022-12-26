using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.Core.ProjectAggregate;

namespace CantinaUPT_API.Core.Interfaces;
public interface ICanteenService
{
  Task<List<Canteen>> GetEveryCanteensDetails();
  Task<Canteen> GetMealsOfCanteen(int canteenId);
  Task<Canteen> GetMenusOfCanteen(int canteenId);
  Task AssignMealToCanteen(int canteenId, Meal meal);
  Task AssignMealsToCanteen(int canteenId, List<Meal> meals);
  Task AssignMealsByIdToCanteen(int canteenId, List<int> mealIds);
  Task AddCanteen(Canteen canteen);
  Task DeleteCanteen(int canteenId);
  Task UpdateCanteenDetails(int id, Canteen canteen);
}
