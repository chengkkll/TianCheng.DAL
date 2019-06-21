namespace TianCheng.DAL
{
    /// <summary>
    /// 加载数据库操作信息
    /// </summary>
    public class LoadDB
    {
        /// <summary>
        /// 初始化数据库模块
        /// </summary>
        static public void Init()
        {
            foreach (ILoadDB db in Model.AssemblyHelper.GetInstanceByInterface<ILoadDB>())
            {
                db.Init();
            }
        }
    }
}
