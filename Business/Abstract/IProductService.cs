using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetList();
        Task<IDataResult<List<Product>>> GetListAsync();
        IDataResult<Product> GetById(int id);
        Task<IDataResult<Product>> GetByIdAsync(int id);
        IResult Add(Product product);
        Task<IResult> AddByAsync(Product product);
        IResult Delete(Product product);
        Task<IResult> DeleteByAsync(Product product);
        IResult Update(Product product);
        Task<IResult> UpdateByAsync(Product product);
    }
}
