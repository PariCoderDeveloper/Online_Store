using Shop.Application.Interfaces.Context;
using Shop.Ccommon.Dto;

namespace Shop.Application.Services.Product.Command.RemoveProduct
{
    public class RemoveProduct : IRemoveProduct
    {
        private readonly IDataBaseContext _context;
        public RemoveProduct(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> ExecuteAsync(long ProductId)
        {
            try
            {
                var product = await _context.Products.FindAsync(ProductId);
                if (product == null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "محصول در پایگاه داده موجود نیست"
                    };
                }
                product.IsRemoved = true;
                product.RemoveTime = DateTime.Now;

                var productFeatures = _context.ProductFeature
                    .Where(x => x.ProductId == ProductId)
                    .ToList();
                productFeatures.ForEach(x =>
                {
                    x.IsRemoved = true;
                    x.RemoveTime = DateTime.Now;
                });

                var productImage = _context.ProductImage
                    .Where(x => x.ProductId == ProductId)
                    .ToList();
                productImage.ForEach(x =>
                {
                    x.IsRemoved = true;
                    x.RemoveTime = DateTime.Now;
                });

                await _context.SaveChangesAsync();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "محصول با موفقیت حذف شد."
                };
            }
            catch (Exception ex)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }

        }
    }


}
