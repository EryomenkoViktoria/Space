using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace GameDevEVO 
{
    [RequireComponent(typeof(CircleCollider2D), typeof(SpriteRenderer))]
    public class MapPoint : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField]
        private TextMeshPro m_Text;

        [SerializeField]
        private UnityEvent OnClick;

        private int m_Index;

        public void SetParameters(Sprite sprite, int index)
        {
            GetComponent<SpriteRenderer>().sprite=sprite;
            m_Index=index;
            m_Text.text = m_Index.ToString();
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            LevelNameData level = new LevelNameData();
            level.SetName("Game");
            level.SetLevelIndex(m_Index);
            OnClick.Invoke();
        }
    }
}