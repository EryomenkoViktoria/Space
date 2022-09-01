using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public abstract class PlayerCannonBase : MonoBehaviour
 {

        [SerializeField]
        private GameObject m_BulletPrefab;
        private WaitForSeconds m_Wait;
        protected BulletsPool m_BulletsPool;  
        [SerializeField, Range(1, 20)]
        private int m_BulletsCount;
        private void Start()
        {
            m_BulletsPool= FindObjectOfType<BulletsPool>();
            m_BulletsPool.AddBullets(m_BulletPrefab,m_BulletsCount);
            m_Wait = new WaitForSeconds(.5f);
            StartCoroutine(Timer());
        }
        private IEnumerator Timer()
        {
            while (true)
            {
                GetBullet();
                yield return m_Wait;
            }
        }

        protected abstract void GetBullet();
 }
}