using Shop.Ccommon.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.Cart
{
    public interface ICartService
    {
        /// <summary>
        /// وقتی کاربر یک محصول را به سبد خرید اضافه میکند، به طور خودکار سبد خرید ایجاد میشود و اگر 
        /// سبد خریدی از قبل موجود باشد، محصول به آن افزوده می شود.
        /// </summary>
        /// <returns></returns>
        Task<ResultDto> AddCart(long ProductId, Guid BrowserId);
        /// <summary>
        /// محصولی که آیدی آن به Backend ارسال میشود را از سید خرید مرتبط با آیدی مرورگر حذف میکند
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="BrowserId"></param>
        /// <returns></returns>
        Task<ResultDto> DeleteFromCart(long ProductId, Guid BrowserId);
        /// <summary>
        /// آیتم های یک سبد خرید را برمیگرداند، همچنین سبد خرید را نیز برای کاربر ست میکند.
        /// </summary>
        /// <param name="BrowserId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<ResultDto<CartDto>> GetItemsCart(Guid BrowserId, long? UserId);
    }
}
