using System;
using System.Collections;
using System.Collections.Generic;
using SpaceRunner.Abstracts.Utilities;
using UnityEngine;

namespace SpaceRunner.Managers
{
    public class GameManager : SingletonMonoBehaviourObject<GameManager>
    {
        private void Awake()
        {
            SingletonThisObject(this);
        }
        
        public void StopGame()
        {
            Time.timeScale = 0f;
        }
    }
}
