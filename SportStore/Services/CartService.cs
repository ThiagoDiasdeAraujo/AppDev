using SportStore.Entities;
using SportStore.Helpers;
using SportStore.Models;
using SportStore.Repositories;
using SportStore.ViewModels.Cart;
using SportStore.ViewModels.Product;
using System.Text.Json;
using System.Xml.Schema;

namespace SportStore.Services
{
    public class CartService : ICartService
    {
        private IProductRepository _productRepo;

        private readonly IHttpContextAccessor _contextAccessor;

        public CartService(IProductRepository productRepo, IHttpContextAccessor contextAccessor)
        {
            _productRepo = productRepo;
            _contextAccessor = contextAccessor;
        }

        public void AddCartLineToCart(int productID, int quantity)
        {
            if (productID != 0 && quantity != 0)
            {
                Cart cart = GetCartFromSession();

                CartLine existingLine = cart.CartLines.FirstOrDefault(cl => cl.ProductID == productID);

                if (existingLine != null)
                {
                    // Indien er reeds een lijn voor het gekozen product bestaat, verhoogt het aantal van de lijn met het nieuwe aantal.
                    existingLine.Quantity += quantity;
                }
                else
                {
                    // Anders maak een nieuw lijn
                    cart.CartLines.Add(new CartLine()
                    {
                        ProductID = productID,
                        Quantity = quantity
                    });
                }
                AddCartToSession(cart);

            }
        }

        public CartDetailViewModel GetCartDetails()
        {
            Cart cart = GetCartFromSession();

            CartDetailViewModel cartDetails = new CartDetailViewModel
            {
                CartItems = cart.CartLines.Select(cartItem => new CartDetailsModel
                {
                    ProductName = GetProductName(cartItem.ProductID),
                    Price = GetProductPrice(cartItem.ProductID),
                    Quantity = cartItem.Quantity,
                    SubTotal = cartItem.Quantity * GetProductPrice(cartItem.ProductID),
                }),

                Total = 0
            };
            return cartDetails;
        }

        private string GetProductName(int id)
        {
            return _productRepo.GetById(id).Name;
        }

        private decimal GetProductPrice(int id)
        {
            return _productRepo.GetById(id).Price;
        }

        private void AddCartToSession(Cart cart)
        {
            if (cart != null)
            {
                _contextAccessor.HttpContext.Session.SetObjectAsJson("cart", cart);
            }
        }

        private Cart GetCartFromSession()
        {
            Cart cart = _contextAccessor.HttpContext.Session.GetObjectFromJson<Cart>("cart");
            if (cart == null)
            {
                cart = new()
                {
                    CartLines = new List<CartLine>()
                };            
            }

            return cart;
        }
    }
}



