using Mirror;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float movementSpeed;
    
    [SerializeField] private PlayerBodyRotation playerBodyRotation;
    
    private PlayerAnimations _playerAnimations;
    
    private Rigidbody _rigidbody;
    
    private Transform _cameraTransform;

    private IMovement _movement;

    private Vector3 _direction;
    private Vector3 _zeroVector = Vector3.zero;
    
    private bool _isRunning;

    private float _hor;
    private float _ver;


    public override void OnStartLocalPlayer()
    {
        if(!isLocalPlayer)
            return;

        _rigidbody = GetComponent<Rigidbody>();

        _playerAnimations = GetComponent<PlayerAnimations>();

        _cameraTransform = Camera.main.transform;

        _movement = new KeyboardMovement();
    }

    private void FixedUpdate()
    {
        if(!isLocalPlayer)
            return;
        
        Movement();
    }

    private void Movement()
    {
        _movement.Move(ref _direction, _cameraTransform);
        
        _rigidbody.MovePosition(_rigidbody.position + _direction * movementSpeed * Time.fixedDeltaTime);

        playerBodyRotation.Rotation(_direction);
        
        if (_direction == _zeroVector)
            _isRunning = false;
        else
            _isRunning = true;
        
        _playerAnimations.MovementAnimation(_isRunning);
    }
    
    
}