using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class BackgroundImages : MonoBehaviour
 {

        [SerializeField]
        private List<Sprite> m_Sprite;

        private float m_OffsetY = 0f;

        private void Start()
        {
            if(m_Sprite.Count > 0)
            {
                SetImagesPosition();
            }
        }

        private void SetImagesPosition()
        {
            transform.position = new Vector2(transform.position.x, new SafeAreaData().GetMin().y);

            for( int i= 0; i < m_Sprite.Count; i++)
            {
                GameObject image = new GameObject("image", typeof(SpriteRenderer));
                image.GetComponent<SpriteRenderer>().sprite = m_Sprite[i];
                image.transform.SetParent(transform);
                image.transform.position = new Vector2(transform.position.x, transform.position.y+m_OffsetY );
                m_OffsetY += m_Sprite[i].bounds.size.y;
            }
        }
    }
}