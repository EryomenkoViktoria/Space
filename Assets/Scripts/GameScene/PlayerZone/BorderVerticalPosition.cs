using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class BorderVerticalPosition : MonoBehaviour
 {
        [SerializeField]
        private Camera m_Camera;

        [SerializeField]
        private bool m_IsUp;

        private void Start()
        {
            SetPosition();
        }
        private void SetPosition()
        {
            Vector2 safeAreaPotion = m_IsUp ? Screen.safeArea.max : Screen.safeArea.min;
            float positionY = m_Camera.ScreenToWorldPoint(safeAreaPotion).y;
            transform.position = new Vector2(transform.position.x, positionY);
        }

 }
}