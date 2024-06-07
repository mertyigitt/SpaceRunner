using System;
using System.Collections;
using System.Collections.Generic;
using SpaceRunner.Managers;
using SpaceRunner.ScriptableObjects;
using UnityEngine;

namespace SpaceRunner.Controllers
{
    public class LevelInitializerController : MonoBehaviour
    {
        #region Self Variables

        #region Private Variables

        private LevelDifficultyData _levelDifficultyData;

        #endregion

        #endregion

        private void Awake()
        {
            _levelDifficultyData = GameManager.Instance.LevelDifficultyData;
        }

        private void Start()
        {
            RenderSettings.skybox = _levelDifficultyData.SkyBoxMaterial;
            Instantiate(_levelDifficultyData.FloorPrefab);
            Instantiate(_levelDifficultyData.SpawnersPrefab);
            EnemyManager.Instance.SetMoveSpeed(_levelDifficultyData.MoveSpeed);
            EnemyManager.Instance.SetAddDelayTime(_levelDifficultyData.AddDelayTime);
        }
    }
}
