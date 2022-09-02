using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameDevEVO 
{
 public sealed class PlayerHealth : ObjectHealth
 {
        [SerializeField]
        private UnityEvent <int>OnChangeHealth;

        protected override void OnEnable()
        {
            base.OnEnable();
            OnChangeHealth.Invoke(GetCurrentHealth());

        }
        public override void TakeDamage(int value)
        {
            base.TakeDamage(value);
            OnChangeHealth.Invoke(GetCurrentHealth());
        }

        public void PrintHealth()
        {
            Debug.Log(GetCurrentHealth());  
        }
 }
}