using System.Collections;
using UnityEngine;

namespace MasterOfJoints
{
    public class CatapulteHandler : MonoBehaviour
    {
        private const float ErrorRate = 0.1f;

        [SerializeField] private HingeJoint _movedPartJoint;
        [SerializeField] private SpringJoint _projectilePrefab;
        [SerializeField] private Rigidbody _parent;
        [SerializeField] private Transform _projectileSpawnPoint;

        private Coroutine _activeShootCoroutine;
        private Coroutine _activeResetCoroutine;
        private bool _isShooted = false;

        private void Start()
        {
            CreateTail();
        }

        public void Shoot()
        {
            if (_isShooted == true || _activeShootCoroutine != null)
            {
                return;
            }

            _activeShootCoroutine = StartCoroutine(ProcessShoot());
        }

        public void ResetShooting()
        {
            if (_isShooted == false || _activeResetCoroutine != null)
            {
                return;
            }

            _activeResetCoroutine = StartCoroutine(ProcessResetShooting());
        }

        private void CreateTail()
        {
            SpringJoint projectile = Instantiate(
                _projectilePrefab,
                _projectileSpawnPoint.position,
                Quaternion.identity);

            projectile.connectedBody = _parent;
        }

        private IEnumerator ProcessShoot()
        {
            _movedPartJoint.useMotor = true;

            while(Mathf.Abs(_movedPartJoint.limits.max - _movedPartJoint.angle) > ErrorRate)
            {
                yield return null;
            }

            _activeShootCoroutine = null;
            _isShooted = true;
        }

        private IEnumerator ProcessResetShooting()
        {
            _movedPartJoint.useMotor = false;

            while (Mathf.Abs(_movedPartJoint.spring.targetPosition - _movedPartJoint.angle) > ErrorRate)
            {
                yield return null;
            }

            CreateTail();

            _isShooted = false;
            _activeResetCoroutine = null;
        }
    }
}
