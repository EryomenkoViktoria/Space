using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
    public class BulletsPool : MonoBehaviour
    {
        private readonly Dictionary<string, List<GameObject>> m_Bullets = new Dictionary<string, List<GameObject>>();
        public void AddBullets(GameObject bulletPrefab, int count)
        {
            if (m_Bullets.ContainsKey(bulletPrefab.name) == false)
            {
                m_Bullets.Add(bulletPrefab.name, new List<GameObject>());
            }

            for (int i = 0; i < count; i++)
            {
                Create(bulletPrefab);
            }
        }

        private GameObject Create(GameObject bulletPrefab)
        {
            var bullet = Instantiate(bulletPrefab, transform);
            bullet.SetActive(false);
            m_Bullets[bulletPrefab.name].Add(bullet);
            return bullet;
        }

        public GameObject GetBullet(GameObject bulletPrefab)
        {
            if (m_Bullets.ContainsKey(bulletPrefab.name))
            {
                for (int i = 0; i < m_Bullets.Count; i++)
                {
                    if (!m_Bullets[bulletPrefab.name][i].activeInHierarchy)
                        return m_Bullets[bulletPrefab.name][i];
                }
                return Create(bulletPrefab);
            }
            else
                m_Bullets.Add(bulletPrefab.name, new List<GameObject>());
            return Create(bulletPrefab);
        }
    }
}