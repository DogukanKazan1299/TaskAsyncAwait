using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()//product için validasyonlar
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adı boş geçilemez..");
            RuleFor(x => x.ProductName).MaximumLength(20).WithMessage("Max 20 karakter alabilir");
            RuleFor(x => x.ProductName).MinimumLength(3).WithMessage("Min 3 karakter olmalıdır..");
        }
    }
}
