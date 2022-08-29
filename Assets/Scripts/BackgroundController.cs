using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
     public class BackgroundController : MonoBehaviour
     {
        [SerializeField]
        private SpriteRenderer m_Sprite;
        private float m_Speed = 0.5f;
        private float m_PositionMinY;
        private Vector2 m_RestertPosition;
        private void Awake()
        {
            m_RestertPosition = transform.position;
            m_PositionMinY = m_Sprite.bounds.size.y * 2 - m_RestertPosition.y;
        }
        private void Update()
        {
            transform.Translate(Vector3.down * m_Speed*Time.deltaTime);
            if(transform.position.y <- m_PositionMinY)
            {
                transform.position = m_RestertPosition;
            }
        }
    }
}