using System;
using System.Reflection;

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
        public static TEntity Build(params dynamic[] valueParms)
        {
            TEntity entity = System.Activator.CreateInstance<TEntity>();        // new instance of TEntity
            PropertyInfo[] propertyInfos = entity.GetType().GetProperties();    //get the all public Properties
            if (propertyInfos.Length != valueParms.Length) throw new ArgumentException("arguments count not matching --qixiao");    //if arguments`s count not matching throw an exception
            for (int i = 0; i < propertyInfos.Length; i++)
                propertyInfos[i].SetValue(entity, valueParms[i]);                    //set value for properties
            return entity;
        }
    }
}
