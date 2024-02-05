using Microsoft.EntityFrameworkCore;
using Paskaita14.Models;

namespace Paskaita14.DataLayer
{
    public class DbRepository : IDbRepository
    {
        private readonly ShoppingListDbContext _shoppingListDbContext;

        public DbRepository(ShoppingListDbContext shoppingListDbContext)
        {
            _shoppingListDbContext = shoppingListDbContext;
        }

        public int CreateShoppingList(ShoppingList shoppingList)
        {
            _shoppingListDbContext.ShoppingLists.Add(shoppingList);
            _shoppingListDbContext.SaveChanges();
            return shoppingList.Id;
        }

        public void DeleteShoppingList(int id)
        {
            var shoppingList = _shoppingListDbContext.ShoppingLists.Find(id);
            _shoppingListDbContext.ShoppingLists.Remove(shoppingList);

            // efektyvesnis budas:
            // var shoppingList = new ShoppingList { Id = id };
            // _shoppingListDbContext.ShoppingLists.Attach(shoppingList);
            // _shoppingListDbContext.ShoppingLists.Remove(shoppingList);

            _shoppingListDbContext.SaveChanges();
        }

        public ShoppingList GetShoppingListById(int id)
        {
            return _shoppingListDbContext.ShoppingLists.Include(s => s.Items).FirstOrDefault(s => s.Id == id);
        }

        public List<ShoppingList> GetShoppingListByUserId(int userId)
        {
            return _shoppingListDbContext.ShoppingLists.Include(s => s.Items).Where(x => x.UserId == userId).ToList();
        }

        public void UpdateShoppingList(ShoppingList shoppingList)
        {
            _shoppingListDbContext.ShoppingLists.Update(shoppingList);
            _shoppingListDbContext.SaveChanges();
        }
    }
}
