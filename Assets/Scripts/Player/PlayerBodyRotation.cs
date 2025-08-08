using Mirror;
using UnityEngine;

public class PlayerBodyRotation : NetworkBehaviour
{
    [SerializeField] private float rotationSpeed;
    
    private Vector3 _zeroVector = Vector3.zero;

    private Transform _transform;


    public override void OnStartLocalPlayer()
    {
        _transform = transform;
    }


    public void Rotation(Vector3 direction)
    {
        if (direction == _zeroVector)
            return;
        
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        
        _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);

    }
}