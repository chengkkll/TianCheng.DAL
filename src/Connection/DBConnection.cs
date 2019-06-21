using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using TianCheng.Model;

namespace TianCheng.DAL
{
    /// <summary>
    /// 数据库的连接信息
    /// </summary>
    public class DBConnection
    {
        /// <summary>
        /// 获取配置信息的句柄
        /// </summary>
        private readonly IOptionsMonitor<List<DBConnectionOptions>> OptionsMonitor;
        /// <summary>
        /// 数据库连接配置
        /// </summary>
        public List<DBConnectionOptions> ConnectionList { get; private set; } = new List<DBConnectionOptions>();
        /// <summary>
        /// 默认的连接项名称
        /// </summary>
        public const string DefaultOptionName = "default";
        /// <summary>
        /// 配置文件中的连接数据库节点名称
        /// </summary>
        public const string DBConnectionNodeName = "DBConnection";
        /// <summary>
        /// 默认的数据库连接
        /// </summary>
        public DBConnectionOptions Default
        {
            get
            {
                if (ConnectionList.Where(e => e.Name == DefaultOptionName).Count() == 1)
                {
                    return ConnectionList.Where(e => e.Name == DefaultOptionName).FirstOrDefault();
                }
                var conn = ConnectionList.FirstOrDefault();
                if (conn == null)
                {
                    ApiException.ThrowBadRequest("请填写数据库的连接配置");
                }
                if (string.IsNullOrWhiteSpace(conn.Name))
                {
                    conn.Name = DefaultOptionName;
                }
                return conn;
            }
        }

        /// <summary>
        /// 根据连接的名称获取连接信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DBConnectionOptions ByName(string name)
        {
            var conn = ConnectionList.Where(e => e.Name == name).FirstOrDefault();
            if (conn == null)
            {
                ApiException.ThrowBadRequest($"请完善名称为{name}的数据库连接配置");
            }
            return conn;
        }

        /// <summary>
        /// 创建一个数据库连接
        /// </summary>
        /// <param name="dbType"></param>
        /// <param name="connectChange">连接改变时的处理</param>
        public DBConnection(DBType dbType = DBType.MongoDB, Action<List<DBConnectionOptions>> connectChange = null)
        {
            OptionsMonitor = ServiceLoader.GetService<IOptionsMonitor<List<DBConnectionOptions>>>();
            OptionsMonitor.OnChange(_ =>
            {
                _ = ServiceLoader.BuildConfiguration().GetSection(DBConnectionNodeName).Get<List<DBConnectionOptions>>();
                ConnectionList = _.Where(e => e.Type == dbType).ToList();

                connectChange?.Invoke(ConnectionList);
            });

            ConnectionList = OptionsMonitor.CurrentValue.Where(e => e.Type == dbType).ToList();
        }
    }
}
