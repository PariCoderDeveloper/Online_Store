using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Context;
using Shop.Ccommon.Dto;
using Shop.Domain.Entities.Cart;

namespace Shop.Application.Services.Cart
{
    public class CartService : ICartService
    {
        private readonly IDataBaseContext _context;
        public CartService(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> AddCart(long ProductId, Guid BrowserId)
        {
            var carts = await _context.Carts.Where(x => x.BrowserId == BrowserId && x.Finished == false).FirstOrDefaultAsync();
            if (carts == null)
            {
                Carts newCart = new Carts
                {
                    BrowserId = BrowserId,
                    Finished = false,
                };
                await _context.Carts.AddAsync(newCart);
                await _context.SaveChangesAsync();
                carts = newCart;
            }

            var product = await _context.Products.FindAsync(ProductId);
            var Item = await _context.CartItems.Where(x => x.ProductId == ProductId && x.CartId == carts.Id).FirstOrDefaultAsync();
            if (Item != null)
            {
                Item.Count++;
            }
            else
            {
                CartItem cartItem = new CartItem
                {
                    Product = product,
                    Count = 1,
                    Cart = carts,
                    Price = product.Price,
                };
                await _context.CartItems.AddAsync(cartItem);
                await _context.SaveChangesAsync();
            }
            return new ResultDto
            {
                IsSuccess = true,
                Message =""
            };
        }

        public async Task<ResultDto> DeleteFromCart(long ProductId, Guid BrowserId)
        {
            var Item = await _context.CartItems.Include(x => x.Cart).Where(x => x.ProductId == ProductId 

            && x.Cart.BrowserId == BrowserId).FirstOrDefaultAsync();
            if (Item != null) {
                Item.IsRemoved = true;
                Item.RemoveTime = DateTime.Now;
                await _context.SaveChangesAsync();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = ""
                };
            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = ""
                };
            }
        }

        public async Task<ResultDto<CartDto>> GetItemsCart(Guid BrowserId, long? UserId)
        {
            try
            {
                var cart = await _context.Carts
                 .Include(x => x.Items)
                 .ThenInclude(x => x.Product)
                 .ThenInclude(x => x.ProductImages)
                 .Where(x => x.BrowserId == BrowserId && x.Finished == false)
                 .OrderByDescending(x => x.Id)
                 .FirstOrDefaultAsync();
                if (cart == null)
                {
                    return new ResultDto<CartDto>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = ""
                    };
                }
                if (UserId != null)
                {
                    var user = _context.Users.Find(UserId);
                    cart.Users = user;
                    await _context.SaveChangesAsync();
                }
                return new ResultDto<CartDto>()
                {
                    Data = new CartDto
                    {
                        ProductCount = cart.Items.Count(),
                        SumAmount = cart.Items.Sum(x => x.Price * x.Count),
                        Items = cart.Items.Select(x => new CartItemDto
                        {
                            Count = x.Count,
                            Id = x.ProductId,
                            Price = x.Price,
                            Images = x.Product?.ProductImages?.FirstOrDefault()?.Src,
                            Product = x.Product.Name
                        }).ToList(),

                    },
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new ResultDto<CartDto>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message
                };
            }     
                
        }
    }
}
