using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
    [RequireComponent(typeof(Rigidbody2D))]
 public class BulletMove : MonoBehaviour
 {
        [SerializeField, Range(10, 35)]
        private float m_Speed = 25f;

        [SerializeField]
        private Rigidbody2D m_Rigidbody2d;

        private void FixedUpdate()
        {
            m_Rigidbody2d.velocity = transform.up * m_Speed;
        }

    }
}