using System;
using System.Collections;
using System.Collections.Generic;
using SpaceRunner.Abstracts.Utilities;
using SpaceRunner.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceRunner.Managers
{
    public class GameManager : SingletonMonoBehaviourObject<GameManager>
    {
        #region Self Variables

        #region Serialized VAriables

        [SerializeField] private LevelDifficultyData[] _levelDifficultyDatas;

        #endregion

        #region Private Variables

        private int _difficultyIndex;

        #endregion
        
        #region Public Variables

        public int DifficultyIndex 
        { 
            get => _difficultyIndex;
            set
            {
                if (_difficultyIndex < 0 || _difficultyIndex > _levelDifficultyDatas.Length)
                {
                    LoadScene("Menu");
                }
                else
                {
                    _difficultyIndex = value;
                }
            }
        }
        public event Action OnGameStop;
        public LevelDifficultyData LevelDifficultyData => _levelDifficultyDatas[DifficultyIndex];
        

        #endregion

        #endregion
        
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
