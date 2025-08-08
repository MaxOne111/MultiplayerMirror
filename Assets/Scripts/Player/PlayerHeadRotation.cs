using Mirror;
using UnityEngine;

public class PlayerHeadRotation : NetworkBehaviour
{
    private float _axisX;

    private float _currentAxisX;

    private Transform _transform;
    
    private Transform _cameraTransform;

    private IRotation _rotation;


    public override void OnStartLocalPlayer()
    {
        if(!isLocalPlayer)
            return;
        
        _transform = transform;
        
        _cameraTransform = Camera.main.transform;
        
        _cameraTransform.SetParent(_transform);

        _rotation = new MouseRotation(_transform);
    }
    

    private void LateUpdate()
    {
        if(!isLocalPlayer)
            return;
        
        _rotation.Rotate();
    }
    
    private void OnDisable()
    {
        if(!isLocalPlayer)
            return;
        
        _cameraTransform.SetParent(null);
    }
}