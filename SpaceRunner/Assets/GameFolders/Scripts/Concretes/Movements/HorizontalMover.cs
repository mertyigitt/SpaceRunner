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
        #region Self Variables

        #region Private Variables
        
        private IEntityController _entityController;

        #endregion

        #endregion
        
        public HorizontalMover(IEntityController entityController)
        {
            _entityController = entityController;        }
        
        public void FixedTick(float horizontal)
        {
            if (horizontal == 0f) return;
            
            _entityController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * _entityController.MoveSpeed);

            float xBoundary = Mathf.Clamp(_entityController.transform.position.x, -_entityController.MoveBoundary, _entityController.MoveBoundary);
            _entityController.transform.position = new Vector3(xBoundary, _entityController.transform.position.y, 0f);
        }
    }
}
