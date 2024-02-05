using Paskaita14.DTOs;
using Paskaita14.Models;

namespace Paskaita14.BusinessLogic
{
    public interface IShoppingListMapper
    {
        ShoppingList Map(CreateShoppingListDTO shoppingListDTO, int userId);
    }
}
