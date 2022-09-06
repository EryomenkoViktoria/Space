using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameDevEVO 
{
    public class ScoreCollector : MonoBehaviour
    {
        private static int m_ScoreCollected;

        [SerializeField]
        private UnityEvent<int> ScoreChanged; 

        private void OnEnable()
        {
            ObjectScore.OnChanged += ObjectScore_OnChanged;
        }
        private void OnDisable()
        {
            ObjectScore.OnChanged -= ObjectScore_OnChanged;
        }
        private void ObjectScore_OnChanged(int value)
        {
            m_ScoreCollected += value;
            ScoreChanged.Invoke(m_ScoreCollected);
        }

        private void Awake()
        {
            ScoreChanged.Invoke(m_ScoreCollected);
        }
    }
}