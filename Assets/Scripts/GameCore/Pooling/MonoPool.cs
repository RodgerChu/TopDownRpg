using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GameCore.Pooling
{
    public class MonoPool<TBase>where TBase: PoolableMonoBehaviour
    {
        [Inject] private DiContainer m_container;
        
        private Transform m_parent;
        private List<TBase> m_pool = new(15);

        public MonoPool()
        {
            var poolParent = new GameObject("MonoPool_" + typeof(TBase).Name);
            m_parent = poolParent.transform;
        }

        public TConcrete Get<TConcrete>(TConcrete prefab) where TConcrete: TBase, new()
        {
            if (m_pool.Count > 0)
            {
                var item = m_pool[0];
                m_pool.RemoveAt(0);
                return item.GetComponent<TConcrete>();
            }

            return m_container.InstantiatePrefabForComponent<TConcrete>(prefab);
        }

        public void Return(TBase go)
        {
            go.gameObject.SetActive(false);
            go.transform.SetParent(m_parent);
            m_pool.Add(go);
        }
    }
}
