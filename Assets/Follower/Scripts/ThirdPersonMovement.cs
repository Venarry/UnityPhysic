using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonMovement : MonoBehaviour
{
    private const string VectorHorizontal = "Horizontal";
    private const string VectorVertical = "Vertical";

    [SerializeField] private float _speed = 7f;
    
    private CharacterController _characterController;
    private IInputProvider _inputService;
    private Vector3 _moveDirection;

    public float Speed => _speed;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Init(IInputProvider inputService)
    {
        _inputService = inputService;
    }

    private void Update()
    {
        SetMoveDirection();
        Move();
    }

    private void SetMoveDirection()
    {
        Vector3 moveDirection = _inputService.MoveDirection;
        _moveDirection.x = moveDirection.x;
        _moveDirection.z = moveDirection.y;
        _moveDirection = _moveDirection.normalized;

        _moveDirection.y = -1f;
    }

    private void Move()
    {
        _characterController.Move(_speed * Time.deltaTime * _moveDirection);
    }
}
