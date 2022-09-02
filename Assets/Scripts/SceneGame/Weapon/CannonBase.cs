using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public abstract class CannonBase : MonoBehaviour
 {

        [SerializeField]
        private GameObject m_BulletPrefab;

        protected BulletsPool m_BulletsPool;  

        [SerializeField, Range(0, 20)]
        private int m_BulletsCount;

        private void OnEnable()
        {
            if(m_BulletsPool == null)
            {
                m_BulletsPool = FindObjectOfType<BulletsPool>();
            }
            if (m_BulletsCount > 0)
            {
                m_BulletsPool.AddBullets(m_BulletPrefab, m_BulletsCount);
            }
        }

        protected void BulletActivate(Transform bulletStartPosition)
        {
            var bullet = m_BulletsPool.GetBullet(m_BulletPrefab);
            bullet.transform.position = bulletStartPosition.position;
            bullet.transform.Rotate(transform.rotation.eulerAngles);
            bullet.SetActive(true);
        }
        public abstract void Shot();
 }
}