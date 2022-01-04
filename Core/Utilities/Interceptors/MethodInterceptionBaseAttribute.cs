using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    //attributelar class,methodlar için kullanılabilir.Class seviyesi.
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method , AllowMultiple =true,Inherited =true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor//abstract edip gereken yerlerde ez
    {
        public int Priority { get; set; }//öncelik
        public virtual void Intercept(IInvocation invocation)
        {
            
        }
    }
}
