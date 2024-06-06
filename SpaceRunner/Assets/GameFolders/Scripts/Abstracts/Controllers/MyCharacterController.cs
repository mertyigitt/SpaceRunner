using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceRunner.Abstracts.Controllers
{
    public abstract class MyCharacterController : MonoBehaviour
    {
        [SerializeField] private float moveBoundary = 4.5f;
        [SerializeField] float moveSpeed = 10f;
        
        public float MoveSpeed => moveSpeed;
        public float MoveBoundary => moveBoundary;
    }
}
