using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameDevEVO 
{
 public class SceneLoader : MonoBehaviour
 {
        [SerializeField]
        private string m_SceneNameSaved;

        private readonly LevelNameData m_LevelName = new LevelNameData();

        private void Start()
        {
            if( !string.IsNullOrEmpty(m_SceneNameSaved))
            {
                StartCoroutine(AddScene(m_SceneNameSaved));
            }
        }
        public void Load()
        {
            if (!string.IsNullOrEmpty(m_LevelName.GetName()))
            {
                StartCoroutine(ScenesController(m_LevelName.GetName()));
            }
        }

        private IEnumerator ScenesController(string sceneName)
        {
            if (!string.IsNullOrEmpty(m_SceneNameSaved))
            {
                yield return StartCoroutine(RemoveOldScene());
                yield return StartCoroutine(UnloadResources()); 

            }
            yield return StartCoroutine(AddScene(sceneName));
        }
        private IEnumerator AddScene(string name)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
            while (!asyncOperation.isDone)
            {
                yield return null;
            }
            m_SceneNameSaved = name;
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));
        }

        private IEnumerator RemoveOldScene()
        {
            AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(m_SceneNameSaved);
            while (!asyncOperation.isDone)
            {
                yield return null;
            }
        }

        private IEnumerator UnloadResources()
        {
            AsyncOperation asyncOperation = Resources.UnloadUnusedAssets();
            while (!asyncOperation.isDone)
            {
                yield return null; 

            }
        }
 }
}