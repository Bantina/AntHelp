namespace QX_Frame.Data.Options
{
    /*2016-11-12 20:02:47 author：qixiao*/
    public enum opt_AccountRoleLevel:int
    {
        /// <summary>
        /// general user(default)
        /// </summary>
        USER = 0,
        /// <summary>
        /// application administrator
        /// </summary>
        ADMINISTRATOR = 1,
        /// <summary>
        /// the system administrator
        /// </summary>
        ROOT=2,
        /// <summary>
        /// all ip can visit the application
        /// </summary>
        ALL = 3
    }
}
