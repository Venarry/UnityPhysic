using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset = new(0, 7, -4);
    [SerializeField] private Vector3 _angel = new (60, 0, 0);
    [SerializeField] private float _speed = 5f;

    private Vector3 _targetPosition => _target.position + _offset;

    public void SetTarget(Transform target)
    {
        if (target == null)
            return;

        _target = target;
        transform.position = _targetPosition;
        transform.rotation = Quaternion.Euler(_angel.x, _angel.y, _angel.z);
    }

    private void LateUpdate()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (_target == null)
            return;

        Vector3 targetLerpPosition = Vector3
            .Lerp(transform.position, _targetPosition, _speed * Time.deltaTime);

        transform.position = targetLerpPosition;
    }
}
