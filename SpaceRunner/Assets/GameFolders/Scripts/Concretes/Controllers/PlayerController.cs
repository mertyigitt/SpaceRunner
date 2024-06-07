using System;
using System.Collections;
using System.Collections.Generic;
using SpaceRunner.Abstracts.Controllers;
using SpaceRunner.Abstracts.Inputs;
using SpaceRunner.Abstracts.Movements;
using SpaceRunner.Inputs;
using SpaceRunner.Managers;
using SpaceRunner.Movements;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceRunner.Controllers
{
    public class PlayerController : MyCharacterController, IEntityController
    {
        #region Self Variables

        #region Serialized Variables
        
        [SerializeField] float jumpForce = 500f;

        #endregion

        #region Private Variables
        
        private IMover _mover;
        private IJump _jump;
        private IInputReader _input;
        private float _horizontal;
        private bool isJump;
        private bool _isDead = false;

        #endregion

        #endregion
        
        private void Awake()
        {
            _mover = new HorizontalMover(this);
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
            _mover.FixedTick(_horizontal);

            if (isJump)
            {
                _jump.FixedTick(jumpForce);
            }
            
            isJump = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            IEntityController entityController = other.GetComponent<IEntityController>();

            if (entityController != null)
            {
                _isDead = true;
                GameManager.Instance.StopGame();
            }
        }
    }
}

