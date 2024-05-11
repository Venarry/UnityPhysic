using Configs;
using UnityEngine;

namespace FollowerHomework
{
    public class PlayerFactory
    {
        private readonly Player _prefab = Resources.Load<Player>(ResourcesPath.Player);

        public Player Create(Vector3 position, IInputProvider inputProvider)
        {
            Player player = Object.Instantiate(_prefab, position, Quaternion.identity);
            player.Init(inputProvider);

            return player;
        }
    }
}
