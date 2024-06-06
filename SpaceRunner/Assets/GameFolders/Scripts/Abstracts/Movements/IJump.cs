using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceRunner.Abstracts.Movements
{
    public interface IJump
    {
        void FixedTick(float jumpForce);
    }
}
