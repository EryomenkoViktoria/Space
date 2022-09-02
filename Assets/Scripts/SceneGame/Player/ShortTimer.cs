using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameDevEVO 
{
 public class ShortTimer : MonoBehaviour
 {
        [SerializeField, Range(0.1f, 1f)]
        private float m_ShothInterval = 0.5f;

        [SerializeField]
        private UnityEvent OnShot;

        private WaitForSeconds m_Wait;
        private IEnumerator Timer()
        {
            while (true)
            {
                OnShot.Invoke();
                yield return m_Wait; 
            }
        }

        public void StartTimer()
        {
            m_Wait = new WaitForSeconds(m_ShothInterval);
            StartCoroutine(Timer());
        }
 }
}