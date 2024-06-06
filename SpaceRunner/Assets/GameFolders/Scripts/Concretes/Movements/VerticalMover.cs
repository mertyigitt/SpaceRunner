using System.Collections;
using System.Collections.Generic;
using SpaceRunner.Abstracts.Controllers;
using SpaceRunner.Abstracts.Movements;
using SpaceRunner.Controllers;
using UnityEngine;

namespace SpaceRunner.Movements
{
    public class VerticalMover : IMover
    {
        private IEntityController _entityController;
        private float _moveSpeed;

        public float MoveSpeed => _moveSpeed;

        public VerticalMover(IEntityController entityController)
        {
            _entityController = entityController;
            _moveSpeed = entityController.MoveSpeed;
        }

        public void FixedTick(float vertical = 1)
        {
            _entityController.transform.Translate(Vector3.back * vertical * _moveSpeed * Time.deltaTime);
        }
    }
}
