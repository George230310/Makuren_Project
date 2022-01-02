using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterController : MonoBehaviour
{
    private Vector3 _playerMoveInput;
    private PlayerControls _playerControls;
    private Rigidbody _rigidbody;
    [SerializeField] private float speed = 3.0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerControls = new PlayerControls();
        _playerControls.Enable();
    }

    // Start is called before the first frame update
    private void Start()
    {
        _playerControls.Keyboard.MoveKeys.performed += ctx =>
        {
            _playerMoveInput = new Vector3(ctx.ReadValue<Vector2>().x, _playerMoveInput.y, ctx.ReadValue<Vector2>().y);
        };
        
        _playerControls.Keyboard.MoveKeys.canceled += ctx =>
        {
            _playerMoveInput = new Vector3(ctx.ReadValue<Vector2>().x, _playerMoveInput.y, ctx.ReadValue<Vector2>().y);
        };
    }

    private void Move()
    {
        Transform transform1;
        Vector3 moveVec = (transform1 = transform).TransformDirection(_playerMoveInput * speed * Time.deltaTime);
        _rigidbody.MovePosition(transform1.position + moveVec);
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }
    
    private void FixedUpdate()
    {
        Move();
    }
}
