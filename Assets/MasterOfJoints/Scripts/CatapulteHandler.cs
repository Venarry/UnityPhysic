using System.Collections;
using UnityEngine;

namespace MasterOfJoints
{
    public class CatapulteHandler : MonoBehaviour
    {
        private const float ShootingTime = 1f;
        private const float ShootCooldown = ShootingTime * 2;

        [SerializeField] private HingeJoint _movedPartJoint;
        [SerializeField] private SpringJoint _projectilePrefab;
        [SerializeField] private Rigidbody _parent;
        [SerializeField] private Transform _projectileSpawnPoint;

        private WaitForSeconds _shootingWait = new(ShootingTime);
        private WaitForSeconds _cooldownWait = new(ShootCooldown);
        private Coroutine _activeCoroutine;

        private void Start()
        {
            CreateTail();
        }

        public void Shoot()
        {
            if (_activeCoroutine != null)
            {
                return;
            }

            _activeCoroutine = StartCoroutine(ProcessShoot());
        }

        private void CreateTail()
        {
            SpringJoint projectile = Instantiate(_projectilePrefab, _projectileSpawnPoint.position, Quaternion.identity);
            projectile.connectedBody = _parent;
        }

        private IEnumerator ProcessShoot()
        {
            _movedPartJoint.useMotor = true;
            yield return _shootingWait;
            _movedPartJoint.useMotor = false;
            yield return _cooldownWait;
            CreateTail();
            _activeCoroutine = null;
        }
    }
}
