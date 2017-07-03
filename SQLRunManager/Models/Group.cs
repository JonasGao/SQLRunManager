namespace SQLRunManager.Models
{
    public enum Group: short
    {
        /// <summary>
        /// 特殊用户组，该组只存在一个人，即 Root (id = -1)
        /// </summary>
        Root = -1,
        /// <summary>
        /// 全权限组，可以管理所有内容
        /// </summary>
        Master = 10,
        /// <summary>
        /// 管理组，可以管理 sql 和 db
        /// </summary>
        Manager = 20,
        /// <summary>
        /// 开发人员，只能管理自己的 sql
        /// </summary>
        Developer = 30
    }
}
