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
        #region Self Variables

        #region Private Variable

        private IEntityController _entityController;

        #endregion

        #endregion
        
        public VerticalMover(IEntityController entityController)
        {
            _entityController = entityController;
        }

        public void FixedTick(float vertical = 1)
        {
            _entityController.transform.Translate(Vector3.back * vertical * _entityController.MoveSpeed * Time.deltaTime);
        }
    }
}
