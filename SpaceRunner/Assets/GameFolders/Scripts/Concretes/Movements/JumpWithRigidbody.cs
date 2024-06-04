using System.Collections;
using System.Collections.Generic;
using SpaceRunner.Controllers;
using UnityEngine;

namespace SpaceRunner.Movements
{
    public class JumpWithRigidbody
    {
        private Rigidbody _rigidbody;
        public bool CanJump => _rigidbody.velocity.y != 0;

        public JumpWithRigidbody(PlayerController playerController)
        {
            _rigidbody = playerController.GetComponent<Rigidbody>();
        }
        
        public void TickFixed(float jumpForce)
        {
            if(CanJump) return;
            
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector3.up *  jumpForce * Time.deltaTime);
        }
    }
}
