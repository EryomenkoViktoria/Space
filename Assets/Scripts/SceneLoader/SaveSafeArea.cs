using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class SaveSafeArea : MonoBehaviour
 {
        [SerializeField]
        private Camera m_Camera;

        private void Start()
        {
            SafeAreaData safeAreaData = new SafeAreaData();
            safeAreaData.SetMax(m_Camera.ScreenToWorldPoint(Screen.safeArea.max));
            safeAreaData.SetMin(m_Camera.ScreenToWorldPoint(Screen.safeArea.min));

        }
    }
}