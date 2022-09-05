using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public sealed class BonusHealth : BaseBonus
 {
        [SerializeField, Range(100, 1000)]
        private int m_Health = 100;

        protected override void Activate(GameObject player)
        {
            if(player.TryGetComponent(out PlayerHealth health))
            {
                health.AddHealth(m_Health);
            }
        }
 }
}