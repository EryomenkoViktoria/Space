using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class DestroyEffectGenerator : MonoBehaviour
 {
        private const int DefaultCount = 3;
        [SerializeField]
        private ParticleSystem m_Prefab;

        private List<GameObject> m_Effects = new List<GameObject>();

        private void Awake()
        {
            for(int i = 0; i < DefaultCount; i++)
            {
                Create();
            }
        }

        private GameObject Create()
        {
            GameObject effect = Instantiate(m_Prefab.gameObject, transform);
            m_Effects.Add(effect);

            return effect;
        }

        public GameObject GetFreeEffect()
        {
            foreach(var item in m_Effects)
            {
                if (item.activeInHierarchy == false)
                    return item;
            }
                
            return Create();
        }
    }
}