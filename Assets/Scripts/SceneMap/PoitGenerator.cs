using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameDevEVO 
{
 public class PoitGenerator : MonoBehaviour
 {
        [SerializeField]
        private MapPoint m_PointLabele;

        [SerializeField]
        private GameObject m_PointLocked;

        [SerializeField]
        private GameObject m_Path;

        [SerializeField]
        private List<Sprite> m_Sprites;

        [SerializeField]
        private UnityEvent OnGenerated;

        private void Start()
        {
            Generate();
        }

        private void Generate()
        {
           PointStates pointStates = new PointStates();
            pointStates.States.Add(PointsStates.OneStar);
            pointStates.States.Add(PointsStates.Open);
            pointStates.States.Add(PointsStates.TwoStars);
            pointStates.States.Add(PointsStates.ThreeStars);
            pointStates.States.Add(PointsStates.Locked);
            pointStates.States.Add(PointsStates.Locked);
            pointStates.States.Add(PointsStates.Locked);

            PointPosition pointPosition = new PointPosition();

            Vector2 currentPosition;
            List<Vector2> pointPositions = new List<Vector2>();

            for(int i= 0; i< pointStates.States.Count; i++)
            {
                currentPosition = pointPosition.GetNextPosition();
                pointPositions.Add(currentPosition);

                if (pointStates.States[i] == PointsStates.Locked)
                    Instantiate(m_PointLocked, transform).transform.position = currentPosition;
                else
                {
                    MapPoint point = Instantiate(m_PointLabele, transform);
                    point.transform.position = currentPosition;

                    Sprite sprite = null;

                    switch (pointStates.States[i])
                    {
                        case PointsStates.Open:
                            sprite = m_Sprites[1];
                            break;
                        case PointsStates.OneStar:
                            sprite = m_Sprites[2];
                            break;
                        case PointsStates.TwoStars:
                            sprite = m_Sprites[3];
                            break;
                        case PointsStates.ThreeStars:
                            sprite = m_Sprites[4];
                            break;
                    }
                    point.SetParameters(sprite, i);
                }
            }
        

            for(int i = 0; i<pointPositions.Count-1; i++)
            {
                currentPosition = (pointPositions[i] + pointPositions[i + 1]) / 2;

                var path = Instantiate(m_Path, transform);
                path.transform.position = currentPosition;

                var vector = pointPositions[i + 1] - pointPositions[i];
                var zRotate = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
                path.transform.Rotate(0, 0, zRotate);

            }

            OnGenerated.Invoke();
        }
    }
}