using Configs;
using UnityEngine;

namespace FollowerHomework
{
    public class EnemyFactory
    {
        private readonly Enemy _prefab = Resources.Load<Enemy>(ResourcesPath.Enemy);

        public Enemy Create(Vector3 position)
        {
            return Object.Instantiate(_prefab, position, Quaternion.identity);
        }
    }
}
