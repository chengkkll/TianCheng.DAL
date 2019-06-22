using Microsoft.Extensions.Configuration;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// DAL 针对WebApi的Startup中Configure的处理
    /// </summary>
    static public class DALConfigure
    {
        /// <summary>
        /// Configure 的初始化操作
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        static public void TianChengDALInit(this IApplicationBuilder app, IConfiguration configuration)
        {
            TianCheng.Model.ServiceLoader.Instance = app.ApplicationServices;
            // 初始化数据库模块
            TianCheng.DAL.LoadDB.Init();
        }
    }
}
