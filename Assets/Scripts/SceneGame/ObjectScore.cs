using System;
using UnityEngine;

namespace GameDevEVO 
{
 public class ObjectScore : MonoBehaviour
 {
        public static event Action<int> OnChanged;

        [SerializeField, Range(10, 1000)]
        private int m_Score = 10;

        public void Activate()
        {
            OnChanged?.Invoke(m_Score);
        }
 }
}