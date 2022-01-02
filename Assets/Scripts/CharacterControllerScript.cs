using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerScript : MonoBehaviour
{
    private Vector3 _playerMoveInput;
    private PlayerControls _playerControls;
    private CharacterController _characterController;
    [SerializeField] private float speed = 3.0f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
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
        Vector3 moveVec = transform.TransformDirection(_playerMoveInput);
        Vector3 gravityVec = Vector3.zero;

        if (!_characterController.isGrounded)
        {
            gravityVec += Physics.gravity;
        }
        
        _characterController.Move((moveVec + gravityVec) * (speed * Time.deltaTime));
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }
    
    private void Update()
    {
        Move();
    }
}
