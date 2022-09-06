using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class BonusQueue : MonoBehaviour
 {
        private readonly Queue<GameObject> m_Bonuses = new Queue<GameObject> ();

        private GameObject m_TempObgect;

        public void AddObject(GameObject bonus)
        {
            m_Bonuses.Enqueue(bonus);
        }
        public void Activate( Vector3 position)
        {
            if (m_Bonuses.Count > 0)
            {
                m_TempObgect = m_Bonuses.Dequeue ();
                m_TempObgect.transform.position = position; 
                m_TempObgect.SetActive(true);
            }
        }
 }
}