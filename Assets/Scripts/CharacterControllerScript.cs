using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerScript : MonoBehaviour
{
    private Vector3 _playerMoveInput;
    private PlayerControls _playerControls;
    private CharacterController _characterController;
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private bool receiveShadows;
    [SerializeField] private bool castShadows;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _isGroundedLastFrame;
    private float _delayToIdle;
    private static readonly int Grounded = Animator.StringToHash("Grounded");
    private static readonly int AnimState = Animator.StringToHash("AnimState");

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerControls = new PlayerControls();
        _playerControls.Enable();
        _animator = GetComponent<Animator>();
        _spriteRenderer.receiveShadows = receiveShadows;
        _spriteRenderer.shadowCastingMode = castShadows? ShadowCastingMode.On : ShadowCastingMode.Off;
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

    // currently only supports hero knight's animation
    // needs to make this probably an interface in the future
    private void UpdateAnimations()
    {
        // check if character just landed on ground
        if (!_isGroundedLastFrame && _characterController.isGrounded && _animator != null)
        {
            _isGroundedLastFrame = true;
            _animator.SetBool(Grounded, true);
        }
        
        // check if character starts falling
        if (_isGroundedLastFrame && !_characterController.isGrounded && _animator != null)
        {
            _isGroundedLastFrame = false;
            _animator.SetBool(Grounded, false);
        }
        
        // swap direction of sprite depending on walk direction
        if (_playerMoveInput.x < 0f && _spriteRenderer!= null)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_playerMoveInput.x > 0f && _spriteRenderer != null)
        {
            _spriteRenderer.flipX = false;
        }
        
        // run and idle switch
        if (_playerMoveInput.magnitude > Mathf.Epsilon)
        {
            _delayToIdle = 0.05f;
            _animator.SetInteger(AnimState, 1);
        }
        else
        {
            _delayToIdle -= Time.deltaTime;
            if (_delayToIdle < 0f)
            {
                _animator.SetInteger(AnimState, 0);
            }
        }

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
        UpdateAnimations();
    }
}
