using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        Type _validatorType;//gelen validation için tip kontrolü yapmalıyız!
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Validasyon sınıfı değildir.Lütfen doğru sınıf adlandırması yapınız..");
            }
            _validatorType = validatorType;//tipte sorun yok
        }
        protected override void OnBefore(IInvocation invocation)//OnBefore ile kullan.
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//IValidator tipi olmalı.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//argümanı al 
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//argüman kontrolü
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator,entity);//validate kontrolü
            }
        }
    }
}
