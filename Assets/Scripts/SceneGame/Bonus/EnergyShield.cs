using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
    public class EnergyShield : MonoBehaviour
    {
        [SerializeField]
        private CircleCollider2D m_Collider2D;
        [SerializeField]
        private SpriteRenderer m_SpriteRenderer;
        private float m_CurrentTime;
        private bool m_isEnabled;
        private Transform m_target;

        public bool IsEnabled => m_isEnabled;
        public void Activate(float liveTime, Transform target)
        {
            m_CurrentTime += liveTime;
            if (m_isEnabled == false)
            {
                m_target = target;
                transform.position = target.position;
                ShowShield(true);
                StartCoroutine(Timer());
            }
        }
        private void Update()
        {
            if(m_isEnabled)
            {
                transform.position = m_target.position;
            }
        }
        private void ShowShield(bool value)
        {
            m_Collider2D.enabled = value;
            m_SpriteRenderer.enabled = value;
            m_isEnabled = value;
        }

        private IEnumerator Timer()
        {
            float waitAndStep = 0.5f;
            WaitForSeconds wait = new WaitForSeconds(waitAndStep);
            while (m_CurrentTime > 0)
            {
                m_CurrentTime = waitAndStep;
                yield return wait;
            }
            waitAndStep = 0;
            ShowShield(false);
            transform.SetParent(null);
        }
    }
}