using UnityEngine;

namespace SpaceRunner.Abstracts.Movements
{
    public interface IMover
    {
        void FixedTick(float directtion);
        
    }
}
