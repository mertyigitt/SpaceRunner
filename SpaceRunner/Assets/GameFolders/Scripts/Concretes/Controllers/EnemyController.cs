using System;
using System.Collections;
using System.Collections.Generic;
using SpaceRunner.Movements;
using UnityEngine;

namespace SpaceRunner.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 10f;
        [SerializeField] private float maxLifeTime = 6f;
        
        private VerticalMover _mover;
        float _currentLifeTime = 0f;

        public float MoveSpeed => moveSpeed;

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
            Destroy(this.gameObject);
        }
    }
}
