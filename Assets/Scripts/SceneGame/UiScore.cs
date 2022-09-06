using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GameDevEVO 
{
 public class UiScore : MonoBehaviour
 {
        [SerializeField]
        private TextMeshProUGUI m_Text;
        
        public void ShowValue(int value)
        {
            m_Text.text = value.ToString();
        }
 }
}