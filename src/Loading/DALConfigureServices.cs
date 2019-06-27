using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 注册数据库服务操作
    /// </summary>
    static public class DALConfigureServices
    {
        /// <summary>
        /// 数据库配置模块注册
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void TianChengDALInit(this IServiceCollection services, IConfiguration configuration)
        {
            // 注册数据库模块配置信息
            services.Configure<List<TianCheng.DAL.DBConnectionOptions>>(configuration.GetSection(TianCheng.DAL.DBConnection.DBConnectionNodeName));
            // 注册数据库操作服务
            services.AddDALServices();
        }
    }
}
