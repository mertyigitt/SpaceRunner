using System;
using System.Collections;
using System.Collections.Generic;
using SpaceRunner.Abstracts.Inputs;
using SpaceRunner.Inputs;
using SpaceRunner.Managers;
using SpaceRunner.Movements;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceRunner.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveBoundary = 4.5f;
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] float jumpForce = 500f;
        
        private HorizontalMover _horizontalMover;
        private JumpWithRigidbody _jump;
        private IInputReader _input;
        private float _horizontal;
        private bool isJump;
        private bool _isDead = false;

        public float MoveSpeed => moveSpeed;
        public float MoveBoundary => moveBoundary;
        private void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _jump = new JumpWithRigidbody(this);
            _input = new InputReader(GetComponent<PlayerInput>());
        }

        private void Update()
        {
            if(_isDead) return;
            
            _horizontal = _input.Horizontal;

            if (_input.IsJump)
            {
                isJump = true;
            }
        }

        private void FixedUpdate()
        {
            _horizontalMover.TickFixed(_horizontal);

            if (isJump)
            {
                _jump.TickFixed(jumpForce);
            }
            
            isJump = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            EnemyController enemyController = other.GetComponent<EnemyController>();

            if (enemyController != null)
            {
                _isDead = true;
                GameManager.Instance.StopGame();
            }
        }
    }
}

