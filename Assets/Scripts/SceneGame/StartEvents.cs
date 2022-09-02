using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class StartEvents : MonoBehaviour
 {
        [SerializeField]
        private GameEvent m_StartScene;

        [SerializeField]
        private GameEvent m_GamePlay;

        private void Start()
        {
            m_StartScene.Init();
            m_GamePlay.Init();
        }
    }
}