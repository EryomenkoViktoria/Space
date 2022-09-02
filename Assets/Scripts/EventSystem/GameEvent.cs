using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "SO/Crete Game Event")]
 public class GameEvent : ScriptableObject
 {
        private List<GameEventListener> m_Listeners = new List<GameEventListener>();

        public void RegisterListener(GameEventListener listener)
        {
            m_Listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            m_Listeners.Remove(listener);
        }

        public void Init()
        {
           for (int i = m_Listeners.Count - 1; i>=0; i--)
            {
                m_Listeners[i].InitEvent();
            }
        }
 } 
}