using System;

namespace QX_Frame.App.Base
{
    //author:qixiao
    //time:2017-1-2 21:24:32
    //sum:the entity override

    [Serializable]
    public class Entity<TEntity>
    {
        //New Entity Instance
        public static TEntity Build()
        {
            return Activator.CreateInstance<TEntity>();
        }
    }
}
