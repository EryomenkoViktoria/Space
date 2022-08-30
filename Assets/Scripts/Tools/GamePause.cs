using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameDevEVO 
{
 public class GamePause : MonoBehaviour
 {
        [SerializeField]
        private  UnityEvent OnPaused;

        public void Enable(bool value)
        {
            Time.timeScale = value ? 0 : 1;
        }

        private void OnApplicationPause(bool pause)
        {
            if (pause)
            {
                OnPaused.Invoke();
                Enable(true);
            }
        }
    }
}