using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
    [RequireComponent(typeof(RectTransform))]
 public class PanelSize : MonoBehaviour
 {
        [SerializeField]
        private Location m_Location;
        private void Awake()
        {
            CalculateSafeAres();
        }

        private void CalculateSafeAres()
        {
            var safeArea = Screen.safeArea;
            var anchorMin = safeArea.position;
            var anchorMax = anchorMin + safeArea.size;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            SetAnchors(anchorMin, anchorMax);
        }

        private void SetAnchors(Vector2 anchorMin, Vector2 anchorMax)
        {
           var recTransform = GetComponent<RectTransform>();
            switch (m_Location)
            {
                case Location.Top:
                    recTransform.anchorMin = new Vector2(anchorMin.x, anchorMax.y);
                    if (recTransform.anchorMin.y == recTransform.anchorMax.y)
                    {
                        gameObject.SetActive(false);
                    }
                    break;

                case Location.Centre:
                    recTransform.anchorMin = anchorMin;
                    recTransform.anchorMax = anchorMax;
                    break;
                case Location.Bottom:
                    recTransform.anchorMax = new Vector2(anchorMax.x, anchorMin.y);
                    if( recTransform.anchorMax.y == recTransform.anchorMin.y)
                    {
                        gameObject.SetActive(false);
                    }
                    break;
            }
        }

        public enum Location
        {
            Top,
            Centre,
            Bottom
        }
    }


   
}