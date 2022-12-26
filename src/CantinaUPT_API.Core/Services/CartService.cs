
using CantinaUPT_API.Core.Interfaces;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.Core.ProjectAggregate.Specifications;
using CantinaUPT_API.SharedKernel.Interfaces;

namespace CantinaUPT_API.Core.Services;
public class CartService : ICartService
{
  private readonly IReadRepository<CartItem> _readRepository;
  private readonly IRepository<CartItem> _repository;
  private readonly IMealService _mealService;

  public CartService(IReadRepository<CartItem> readRepository, IRepository<CartItem> repository, IMealService mealService)
  {
    _readRepository = readRepository;
    _repository = repository;
    _mealService = mealService;
  }

  public async Task AddToCart(int mealId)
  {
    var meal = await _mealService.GetMeal(mealId);
    var newCartItem = new CartItem { Meal = meal, Quantity = 1, UserId = 1 };

    var specification = new CheckIfItemIsAlreadyInCart(newCartItem);
    var itemAlreadyInCart = await _readRepository.AnyAsync(specification);

    if (!itemAlreadyInCart)
    {
      await _repository.AddAsync(newCartItem);
      await _repository.SaveChangesAsync();
    }
  }

  public async Task IncreaseQuantity(int cartItemId)
  {
    var cartItem = await _readRepository.GetByIdAsync(cartItemId);
    cartItem.Quantity++;
    await _repository.UpdateAsync(cartItem);
    await _repository.SaveChangesAsync();
  }

  public async Task DecreaseQuantityOrDelete(int cartItemId)
  {
    var cartItem = await _readRepository.GetByIdAsync(cartItemId);
    if(cartItem.Quantity > 1)
    {
      cartItem.Quantity--;
      await _repository.UpdateAsync(cartItem);
      await _repository.SaveChangesAsync();
    }
    else
    {
      await _repository.DeleteAsync(cartItem);
      await _repository.SaveChangesAsync();
    }
    
  }

  public async Task<List<CartItem>> GetCartItems()
  {
    var specification = new UsersCartItems(1);
    return await _readRepository.ListAsync(specification);
  }

  public async Task DeleteCartItems()
  {
    var specification = new UsersCartItems(1);
    var cartItems = await _readRepository.ListAsync(specification);
    await _repository.DeleteRangeAsync(cartItems);
    await _repository.SaveChangesAsync(); 
  }
}
