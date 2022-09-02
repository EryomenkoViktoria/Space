using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameDevEVO 
{
 public class Loader : MonoBehaviour
 {
        [SerializeField]
        private SceneName m_SceneName;

        public void Load()
        {
            SceneManager.LoadSceneAsync(m_SceneName.ToString());
        }


    }
    public enum SceneName
    {
        Scene1,
        Scene2
    }
}