using System;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 自动注册服务
    /// </summary>
    static public class DALRegister
    {
        /// <summary>
        /// 增加业务的Service
        /// </summary>
        /// <param name="services"></param>
        public static void AddDALServices(this IServiceCollection services)
        {
            // 注册数据库操作
            foreach (var type in TianCheng.Model.AssemblyHelper.GetTypeByInterfaceName("IDBOperation"))
            {
                if (!type.IsInterface)
                    services.AddTransient(type);
            }
        }
    }
}
