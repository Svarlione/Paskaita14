using Paskaita14.DTOs;
using Paskaita14.Models;

namespace Paskaita14.BusinessLogic
{
    public class ShoppingListMapper : IShoppingListMapper
    {
        public ShoppingList Map(CreateShoppingListDTO shoppingListDTO, int userId)
        {
            var shoppingListItemsEntities = shoppingListDTO.Items.Select((x, i) => new ShoppingListItem
            {
                Title = x.Title,
                Quantity = x.Quantity,
                Order = i + 1
            }).ToList();

            var shoppingListEntity = new ShoppingList
            {
                Title = shoppingListDTO.Title,
                UserId = userId,
                Description = shoppingListDTO.Description,
                Items = shoppingListItemsEntities
            };

            return shoppingListEntity;
        }
    }
}
