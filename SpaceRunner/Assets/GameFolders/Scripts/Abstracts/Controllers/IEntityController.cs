using UnityEngine;

namespace SpaceRunner.Abstracts.Controllers
{
    public interface IEntityController
    {
        Transform transform { get; }
        float MoveSpeed { get;}
        public float MoveBoundary { get;}
    }
}
