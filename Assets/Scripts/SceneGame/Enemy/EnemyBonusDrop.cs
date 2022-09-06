using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
    public class EnemyBonusDrop : MonoBehaviour
    {
        private bool m_HaveBonus;
        private BonusQueue m_BonusQueue;

        public void SetBonusQueue(BonusQueue bonusQueue)
        {
            m_BonusQueue = bonusQueue;
        }

        public void SetHaveBonus(bool value)
        {
            m_HaveBonus = value;
        }

        public void Activate()
        {
            if (m_HaveBonus)
            {
                m_BonusQueue.Activate(transform.position);
            }
        }
    }
}