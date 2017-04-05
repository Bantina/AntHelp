namespace QX_Frame.Data.Options
{
    public enum opt_AccountStatusLevel:int
    {
        /// <summary>
        /// normal status (default)
        /// </summary>
        NORMAL=0,
        /// <summary>
        /// account stop
        /// </summary>
        STOP=1,
        /// <summary>
        /// account freeze
        /// </summary>
        FREEZE=2,
        /// <summary>
        /// account abandon
        /// </summary>
        ABANDON=3
    }
}
