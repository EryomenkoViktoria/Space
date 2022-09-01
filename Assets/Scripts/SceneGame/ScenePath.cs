using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class ScenePath : MonoBehaviour
 {
        [SerializeField]
        private List<Transform> m_PathPoints = new List<Transform>();

        private void Awake()
        {
            Destroy(gameObject);
        }
        public void AddPoint(Transform point)
        {
            m_PathPoints.Add(point);
        }

        public List<Vector2> GetPathPOints()
        {
            List<Vector2> points = new List<Vector2>();

             foreach(var item in m_PathPoints)
            {
                points.Add(item.position);
            }
            return points;
        }
 }
}