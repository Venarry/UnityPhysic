using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FollowerHomework
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour
    {
        private const float SpeedMultiplier = 0.9f;

        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private bool _isGrounded;
        [SerializeField] private float _groundGravity;
        [SerializeField] private float _airGravity;
        [SerializeField] private float _stopDistance;

        private Rigidbody _rigidbody;
        private ITarget _target;

        private float _speed => _target.Speed * SpeedMultiplier;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Set(ITarget target)
        {
            if (target == null)
                return;

            _target = target;
        }

        private void Update()
        {
            if (_target == null)
                return;

            Vector3 targetDirection = new Vector3(_target.Position.x - transform.position.x, 0, _target.Position.z - transform.position.z).normalized;
            Vector3 rotateDirection = Quaternion.LookRotation(targetDirection).eulerAngles;

            _isGrounded = GetGroundedState();
            
            float gravityForce = _groundGravity;

            if (_isGrounded == false)
            {
                gravityForce = _airGravity;
            }

            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit raycastHit, 0.4f))
            {
                targetDirection = Vector3.ProjectOnPlane(targetDirection, raycastHit.normal);
            }

            Debug.DrawRay(transform.position, targetDirection, Color.red);

            bool canMove = Vector3.Distance(_target.Position, transform.position) > _stopDistance;

            if (canMove == true)
                _rigidbody.MovePosition(transform.position + new Vector3(0, gravityForce, 0) * Time.deltaTime + _speed * Time.deltaTime * targetDirection);

            transform.rotation = Quaternion.Euler(rotateDirection);
        }

        private bool GetGroundedState()
        {
            float groundedCheckRange = 0.3f;

            return Physics.CheckSphere(transform.position, groundedCheckRange, _groundMask);
        }
    }
}
