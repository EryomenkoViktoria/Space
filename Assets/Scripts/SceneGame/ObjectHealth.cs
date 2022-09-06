using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameDevEVO 
{
 public class ObjectHealth : MonoBehaviour,IDamageable
 {
        [SerializeField, Range(100, 1000)]
        private int m_MaxHealth = 200;
        private int m_CurrentHealth;

        [SerializeField]
        private UnityEvent OnEndedHealth;

        protected virtual void OnEnable()
        {
            m_CurrentHealth = m_MaxHealth;
        }

        protected int GetCurrentHealth()
        {
            return m_CurrentHealth;
        }

        public virtual void TakeDamage( int value)
        {
            m_CurrentHealth -= value;

            if (m_CurrentHealth <= 0)
            {
                // Destroy(gameObject);
                OnEndedHealth.Invoke();
            }

        }

        public void AddHealth(int value)
        {
            if (value > 0)
            {
                m_CurrentHealth += value;
            }
            if (m_CurrentHealth> m_MaxHealth)
            {
                m_CurrentHealth = m_MaxHealth;
            }
            Debug.Log(m_CurrentHealth);
            
        }
    }
}