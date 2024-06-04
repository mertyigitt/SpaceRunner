using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceRunner.Abstracts.Inputs
{
    public interface IInputReader
    {
        public float Horizontal { get;}
        public bool IsJump { get;}
    }
}
