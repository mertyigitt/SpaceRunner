using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceRunner.Controllers
{
    public class FloorController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] [Range(0.1f, 2f)] private float moveSpeed;

        #endregion

        #region Private Variables

        private Material _material;

        #endregion

        #endregion
        
        private void Awake()
        {
            _material = GetComponentInChildren<MeshRenderer>().material;
        }

        private void Update()
        {
            _material.mainTextureOffset += Vector2.down * moveSpeed * Time.deltaTime;
        }
    }
}
