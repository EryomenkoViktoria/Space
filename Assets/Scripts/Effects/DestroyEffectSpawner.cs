using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
    [RequireComponent(typeof(DestroyEffectGenerator))]
 public class DestroyEffectSpawner : MonoBehaviour
 {
        private DestroyEffectGenerator m_Generator;
        private void Awake()
        {
            m_Generator = GetComponent<DestroyEffectGenerator>();
        }
        private void OnEnable()
        {
            DestroyEffect.OnEffectActivated += DestroyEffect_OnEffectActivated;
        }
        private void OnDisable()
        {
            DestroyEffect.OnEffectActivated -= DestroyEffect_OnEffectActivated;
        }

        private void DestroyEffect_OnEffectActivated(Transform obj)
        {
            GameObject effect = m_Generator.GetFreeEffect();
            effect.transform.position = obj.position;
            effect.SetActive(true);
        }

        
    }
}