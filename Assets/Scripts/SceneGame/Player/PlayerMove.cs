using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMove : MonoBehaviour
     {
        [SerializeField]
        private DynamicJoystick m_Joystick;
        private Rigidbody2D m_Rigidbody2D;
        private float m_Speed = 3f;
        private Vector2 m_Direction = Vector2.zero;

        private void Awake()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if(m_Joystick.Horizontal !=0 || m_Joystick.Vertical != 0)
            {
                m_Direction.y = m_Joystick.Vertical;
                m_Direction.x = m_Joystick.Horizontal;
                m_Rigidbody2D.MovePosition(m_Rigidbody2D.position + m_Speed * Time.fixedDeltaTime * m_Direction);
            }
            else
            {
                m_Rigidbody2D.velocity = Vector2.zero;
            }
        }
    }

}