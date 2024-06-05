using System;
using System.Collections;
using System.Collections.Generic;
using SpaceRunner.Abstracts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceRunner.Managers
{
    public class GameManager : SingletonMonoBehaviourObject<GameManager>
    {
        public event Action OnGameStop;
        
        private void Awake()
        {
            SingletonThisObject(this);
        }
        
        public void StopGame()
        {
            Time.timeScale = 0f;
            OnGameStop?.Invoke();
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            Time.timeScale = 1f;
            yield return SceneManager.LoadSceneAsync(sceneName);
        }

        public void ExitGame()
        {
            Debug.Log("Exit");
            Application.Quit();
        }
    }
}
