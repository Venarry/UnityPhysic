using UnityEngine;

//��������� ������� ������� unity �������� ������������ ��� ��������� ��������� CharacterController,
//� ����� ������������ ��� ���� ��������� Rigidbody.
//��� ���������� ������, �� �� �������� �������� � ���� � ����� �������� ������� ��� � ������.
//����������� �������� ��������� ���������, ������ � �����. ����� � ��� �� ���� ����� ������������ ���������.

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
