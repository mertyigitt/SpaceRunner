using System;
using System.Collections;
using System.Collections.Generic;
using SpaceRunner.Managers;
using UnityEngine;

namespace SpaceRunner.UIs
{
    public class GameCanvas : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private GameOverPanel _gameOverPanel;

        #endregion

        #endregion
        
        private void Awake()
        {
            _gameOverPanel.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameStop += HandleOnGameStop;
        }

        private void HandleOnGameStop()
        {
            _gameOverPanel.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameStop -= HandleOnGameStop;
        }
    }
}
