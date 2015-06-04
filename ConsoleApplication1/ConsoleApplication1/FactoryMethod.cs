// met dank aan Roel van Uden

using System;
using System.Collections.Generic;
using System.Reflection;

namespace ConsoleApplication1
{
    public class FactoryMethod<TKey,TObject>
        where TObject : ICloneable, IGetKey<TKey>
    {
        public static TObject create(TKey cKey)
        {
            return instance()._create(cKey);
        }

        private FactoryMethod()
        {
            m_caObjectMap = new Dictionary<TKey, TObject>();
        }

        private static FactoryMethod<TKey, TObject> instance()
        {
            if (m_cInstance == null)
            {
                m_cInstance = new FactoryMethod<TKey, TObject>();

                m_cInstance.initialize();
            }

            return m_cInstance;
        }

        private TObject _create(TKey cKey)
        {
            if (m_caObjectMap.ContainsKey(cKey))
            {
                TObject cObject = m_caObjectMap[cKey];

                return (TObject)cObject.Clone();
            }
            else
                return default(TObject);
        }

        private void initialize()
        {
            Type[]  caType      = System.Reflection.Assembly.GetExecutingAssembly().GetTypes();
            Type    cBaseType   = typeof( TObject );
            TObject cObject;

            foreach (Type type in caType)
            {
                if (ableToMake(type) && inheritedFromTObject(type,cBaseType))
                {
                    cObject = getDefaultInstance(type);

                    if ( cObject != null )
                        m_caObjectMap.Add(cObject.getKey(), cObject);
                }
            }
        }

        private bool ableToMake(Type type)
        {
            return !type.IsPrimitive && !type.IsAbstract;
        }

        private bool inheritedFromTObject(Type type, Type typeTObject)
        {
            Type cRootType, cNext;

            cNext     = type.BaseType;
            cRootType = cNext;
            while (cNext              != null
                && cRootType.FullName != typeTObject.FullName)
            {
                cRootType = cNext;
                cNext     = cRootType.BaseType;
            }

            return cNext              != null
                && cRootType.FullName == typeTObject.FullName;
        }

        private TObject getDefaultInstance(Type type)
        {
            ConstructorInfo[] constructorInfo = type.GetConstructors();

            for (int n = 0; n < constructorInfo.Length; n++)
            {
                if (constructorInfo[n].GetParameters().Length == 0)
                {
                    return (TObject) constructorInfo[n].Invoke( null );
                }
            }

            return default(TObject);
        }

        private Dictionary<TKey, TObject> m_caObjectMap;
        static private FactoryMethod<TKey, TObject> m_cInstance = null;
    }

    public interface IGetKey<TKey>
    {
        TKey getKey();
    }
}
