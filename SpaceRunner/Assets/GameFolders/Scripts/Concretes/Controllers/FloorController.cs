using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceRunner.Controllers
{
    public class FloorController : MonoBehaviour
    {
        [SerializeField] [Range(0.3f, 2f)] private float moveSpeed;
        private Material _material;

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
