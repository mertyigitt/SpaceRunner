using System;
using System.Collections;
using System.Collections.Generic;
using SpaceRunner.Movements;
using UnityEngine;

namespace SpaceRunner.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float horizontalDirection = 0f;
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] float jumpForce = 500f;
        [SerializeField] private bool isJump;
        
        private HorizontalMover _horizontalMover;
        private JumpWithRigidbody _jump;
        private void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _jump = new JumpWithRigidbody(this);
        }

        private void FixedUpdate()
        {
            _horizontalMover.TickFixed(horizontalDirection, moveSpeed);

            if (isJump)
            {
                _jump.TickFixed(jumpForce);
            }
            
            isJump = false;
        }
    }
}

