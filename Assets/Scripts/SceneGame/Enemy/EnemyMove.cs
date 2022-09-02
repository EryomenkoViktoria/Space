using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameDevEVO 
{
    [RequireComponent(typeof(Rigidbody2D))]
 public class EnemyMove : MonoBehaviour
 {
        private const float Speed = 5f;

        //  private float m_EndPosition;

        [SerializeField]
        private UnityEvent OnCheckPoint;
        private Rigidbody2D m_Rigibody;

        [SerializeField]
        private Path m_Path;
        
        private int m_Index;
        private void Awake()
        {
            m_Rigibody = GetComponent<Rigidbody2D>();
        }
        private void FixedUpdate()
        {
            m_Rigibody.MovePosition(Vector3.MoveTowards(transform.position, m_Path.Points[m_Index], Speed * Time.fixedDeltaTime));

            if(Vector3.Distance(transform.position, m_Path.Points[m_Index]) < 0.01f)
            {
                if (m_Index < m_Path.Points.Count - 1)
                {
                    m_Index++;
                    OnCheckPoint.Invoke();
                }

                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}