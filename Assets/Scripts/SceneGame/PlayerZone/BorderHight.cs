using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
    [RequireComponent (typeof(BoxCollider2D))]
 public class BorderHight : MonoBehaviour
 {
        [SerializeField]
        private Camera m_Camera;

        private const float FullSize = 2f;

        private void Start()
        {
            SetSize();
        }

        private void SetSize()
        {
            float yScale = m_Camera.ScreenToWorldPoint(Screen.safeArea.max).y*FullSize;
            BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
            boxCollider2D.size = new Vector2(boxCollider2D.size.x, yScale);
        }
    }
}