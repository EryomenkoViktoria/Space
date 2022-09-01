using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class PointPosition
 {
        private Vector2 m_Position;
        private float m_OffsetY;

        public PointPosition()
        {
            SafeAreaData safeArea = new SafeAreaData();
            m_Position = safeArea.GetMin();
            m_OffsetY = m_Position.x / 2;
        }

        public Vector2 GetNextPosition()
        {
            m_Position.x = m_OffsetY;
            m_Position.y += Mathf.Abs(m_OffsetY);
            m_OffsetY = -m_OffsetY;

            return m_Position;
        }
    }
}