using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class BonusShield : BaseBonus
 {
        [SerializeField]
        private EnergyShield m_ShieldPrefab;

        [SerializeField]
        private float m_LiveTime = 2f;

        private static EnergyShield m_currentShield;

        private void CheckShield()
        {
            if(m_currentShield == null)
            {
                m_currentShield = Instantiate(m_ShieldPrefab);
            }
        }
        protected override void Activate(GameObject player)
        {
            CheckShield();
            m_currentShield.Activate(m_LiveTime,player.transform);
        }
    }
}