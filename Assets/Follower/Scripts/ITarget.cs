using UnityEngine;

namespace FollowerHomework
{
    public interface ITarget
    {
        public float Speed { get; }
        public Vector3 Position { get; }
    }
}
