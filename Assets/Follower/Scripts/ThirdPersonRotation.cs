using UnityEngine;

public class ThirdPersonRotation : MonoBehaviour
{
    private const string VectorHorizontal = "Horizontal";
    private const string VectorVertical = "Vertical";

    [SerializeField] private float _speed = 0.08f;
    private Vector3 _moveDirection;
    private IInputProvider _inputService;

    public void Init(IInputProvider inputService)
    {
        _inputService = inputService;
    }

    private void Update()
    {
        Vector3 moveDirection = _inputService.MoveDirection;
        _moveDirection.x = moveDirection.x * Time.deltaTime;
        _moveDirection.z = moveDirection.y * Time.deltaTime;
        _moveDirection.y = 0;

        _moveDirection = _moveDirection.normalized;

        if (_moveDirection.magnitude == 0) 
            return;
        
        Quaternion rotateDirection = Quaternion.LookRotation(_moveDirection);
        Quaternion targetRotation = Quaternion.Lerp(transform.rotation, rotateDirection, _speed);

        transform.rotation = targetRotation;
    }
}
