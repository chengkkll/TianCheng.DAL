using System.Collections.Generic;
using System.Linq;

namespace TianCheng.DAL
{
    /// <summary>
    /// 数据库的常用操作接口定义
    /// </summary>
    public interface IDBOperation<T, IdType> where T : Model.IIdModel<IdType>
    {
        #region 查询处理
        /// <summary>
        /// 根据id来查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T SearchByTypeId(IdType id);
        /// <summary>
        /// 根据字符串ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T SearchById(string id);
        /// <summary>
        /// 根据ID列表获取对象集合
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        List<T> SearchByIds(IEnumerable<string> ids);
        /// <summary>
        /// 获取当前集合的查询链式接口
        /// </summary>
        /// <returns></returns>
        IQueryable<T> Queryable();
        /// <summary>
        /// 判断指定属性是否有重复的
        /// </summary>
        /// <param name="objectId">当前对象ID</param>
        /// <param name="prop">属性名</param>
        /// <param name="val">属性值</param>
        /// <param name="ignoreDelete">是否忽略逻辑删除数据</param>
        /// <returns></returns>
        bool HasRepeat(IdType objectId, string prop, string val, bool ignoreDelete);
        #endregion

        #region 数据保存
        #region Save
        /// <summary>
        /// 保存对象，根据ID是否为空来判断是新增还是修改操作
        /// </summary>
        /// <param name="entity"></param>
        void Save(T entity);
        #endregion

        #region 数据的插入
        /// <summary>
        /// 插入单条新数据
        /// </summary>
        /// <param name="entity"></param>
        void InsertObject(T entity);
        /// <summary>
        /// 查询多条数据
        /// </summary>
        /// <param name="entities"></param>
        void InsertRange(IEnumerable<T> entities);
        #endregion

        #region 数据更新
        /// <summary>
        /// 更新单条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateObject(T entity);
        /// <summary>
        /// 更新多条数据
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        void UpdateRange(IEnumerable<T> entities);
        #endregion
        #endregion

        #region 数据删除操作

        #region 物理删除数据
        /// <summary>
        /// 根据ID列表 物理删除一组数据
        /// </summary>
        /// <param name="ids"></param>
        bool RemoveByIdList(IEnumerable<string> ids);
        /// <summary>
        /// 根据ID列表 物理删除一组数据
        /// </summary>
        /// <param name="ids"></param>
        bool RemoveByTypeIdList(IEnumerable<IdType> ids);
        /// <summary>
        /// 根据ID 物理删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T RemoveById(string id);
        /// <summary>
        /// 根据ID 物理删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T RemoveByTypeId(IdType id);
        /// <summary>
        /// 根据对象物理删除数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T RemoveObject(T entity);
        #endregion

        //#region 逻辑删除数据
        ///// <summary>
        ///// 根据ID列表 逻辑删除一组数据
        ///// </summary>
        ///// <param name="ids"></param>
        //bool DeleteByIdList(IEnumerable<string> ids);
        ///// <summary>
        ///// 根据ID列表 逻辑删除一组数据
        ///// </summary>
        ///// <param name="ids"></param>
        //bool DeleteByTypeIdList(IEnumerable<IdType> ids);
        ///// <summary>
        ///// 根据ID 逻辑删除数据
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //bool DeleteById(string id);
        ///// <summary>
        ///// 根据ID 逻辑删除数据
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //bool DeleteByTypeId(IdType id);
        //#endregion

        //#region 取消逻辑删除数据
        ///// <summary>
        ///// 根据ID列表 还原被逻辑删除的一组数据
        ///// </summary>
        ///// <param name="ids"></param>
        //bool UndeleteByIdList(IEnumerable<string> ids);
        ///// <summary>
        ///// 根据ID列表 还原被逻辑删除的一组数据
        ///// </summary>
        ///// <param name="ids"></param>
        //bool UndeleteByTypeIdList(IEnumerable<IdType> ids);
        ///// <summary>
        ///// 根据ID 还原被逻辑删除的数据
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //bool UndeleteById(string id);
        ///// <summary>
        ///// 根据ID 还原被逻辑删除的数据
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //bool UndeleteByTypeId(IdType id);
        //#endregion

        #region 删除表（集合）
        /// <summary>
        /// 删除表（集合）
        /// </summary>
        void Drop();
        #endregion

        #endregion
    }
}
