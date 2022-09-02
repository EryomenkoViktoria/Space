using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameDevEVO 
{
 public class GameEventListener : MonoBehaviour
 {
        [SerializeField]
        private GameEvent m_GameEvent;

        [SerializeField]
        private UnityEvent m_Actions;

        private void OnEnable()
        {
            m_GameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            m_GameEvent.UnregisterListener(this);
        }

        public void InitEvent()
        {
            m_Actions.Invoke();
        }
    }
}