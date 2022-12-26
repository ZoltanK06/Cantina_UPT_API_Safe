using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.Core.ProjectAggregate;

namespace CantinaUPT_API.Core.Interfaces;
public interface ICartService
{
  Task AddToCart(int mealId);
  Task IncreaseQuantity(int cartItemId);
  Task DecreaseQuantityOrDelete(int cartItemId);
  Task<List<CartItem>> GetCartItems();
  Task DeleteCartItems();
}
