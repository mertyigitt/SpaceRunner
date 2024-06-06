using System;
using System.Collections;
using System.Collections.Generic;
using SpaceRunner.Abstracts.Controllers;
using SpaceRunner.Managers;
using SpaceRunner.Movements;
using UnityEngine;

namespace SpaceRunner.Controllers
{
    public class EnemyController : MyCharacterController, IEntityController
    {
        [SerializeField] private float maxLifeTime = 6f;
        
        private VerticalMover _mover;
        float _currentLifeTime = 0f;
        
        private void Awake()
        {
            _mover = new VerticalMover(this);
        }

        private void Update()
        {
            _currentLifeTime += Time.deltaTime;

            if (_currentLifeTime > maxLifeTime)
            {
                _currentLifeTime = 0;
                KillYourSelf();
            }
        }

        private void FixedUpdate()
        {
            _mover.FixedTick();
        }
        
        private void KillYourSelf()
        {
            EnemyManager.Instance.SetPool(this);
        }
    }
}
