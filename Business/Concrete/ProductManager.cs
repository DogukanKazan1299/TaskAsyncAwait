using Business.Abstract;
using Business.Constants;
using Business.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //ValidationTool.Validate(new ProductValidator(), product);--->aspect kullanılmalıdır.
            _productDal.Add(product);
            return new SuccessResult(Messages.AddProduct);
        }

        public async Task<IResult> AddByAsync(Product product)
        {
            await _productDal.AddByAsync(product);
            return new SuccessResult(Messages.AddProduct);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.DeleteProduct);
        }

        public async Task<IResult> DeleteByAsync(Product product)
        {
            await _productDal.DeleteByAsync(product);
            return new SuccessResult(Messages.DeleteProduct);
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.GetById(x => x.ProductId == id));
        }

        public async Task<IDataResult<Product>> GetByIdAsync(int id)
        {
            var result = await _productDal.GetByIdAsync(x => x.ProductId == id);
            return new SuccessDataResult<Product>(result);
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll().ToList());
        }

        public async Task<IDataResult<List<Product>>> GetListAsync()
        {
            var result = await _productDal.GetAllAsync();
            return new SuccessDataResult<List<Product>>(result);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.UpdateProduct);
        }

        public async Task<IResult> UpdateByAsync(Product product)
        {
            await _productDal.UpdateByAsync(product);
            return new SuccessResult(Messages.UpdateProduct);
        }
    }
}
