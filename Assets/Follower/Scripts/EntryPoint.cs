using UnityEngine;

//»спользу€ базовые объекты unity напишите передвижение дл€ персонажа использу€ CharacterController,
//а также передвижение дл€ бота использу€ Rigidbody.
//Ѕот преследует игрока, но не подходит вплотную к нему и имеет скорость меньшую чем у игрока.
//ќб€зательно добавить небольшую ступеньку, подъЄм и спуск. »грок и бот их всех могут преодолевать одинаково.

namespace FollowerHomework
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private CameraMovement _cameraMovement;

        private void Awake()
        {
            IInputProvider inputProvider = new KeyboardInputProvider();
            PlayerFactory playerFactory = new();
            EnemyFactory enemyFactory = new();

            Vector3 playerSpawnPosition = Vector3.zero;
            Player player = playerFactory.Create(playerSpawnPosition, inputProvider);

            _cameraMovement.SetTarget(player.transform);

            Vector3 enemySpawnPosition = new(-2, 0, 0);
            Enemy enemy = enemyFactory.Create(enemySpawnPosition);

            enemy.Set(player);
        }
    }
}
