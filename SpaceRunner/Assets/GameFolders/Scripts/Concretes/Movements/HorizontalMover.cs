using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using SpaceRunner.Abstracts.Controllers;
using SpaceRunner.Abstracts.Movements;
using SpaceRunner.Controllers;
using UnityEngine;

namespace SpaceRunner.Movements
{
    public class HorizontalMover : IMover
    {
        private IEntityController _entityController;
        private float _moveSpeed;
        private float _moveBoundary;

        public float MoveSpeed => _moveSpeed;

        public HorizontalMover(IEntityController entityController)
        {
            _entityController = entityController;
            _moveSpeed = _entityController.MoveSpeed;
            _moveBoundary = entityController.MoveBoundary;
        }
        
        public void FixedTick(float horizontal)
        {
            if (horizontal == 0f) return;
            
            _entityController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * _moveSpeed);

            float xBoundary = Mathf.Clamp(_entityController.transform.position.x, -_moveBoundary, _moveBoundary);
            _entityController.transform.position = new Vector3(xBoundary, _entityController.transform.position.y, 0);
        }
    }
}
