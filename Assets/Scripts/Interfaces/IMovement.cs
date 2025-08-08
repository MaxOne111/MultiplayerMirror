using UnityEngine;

public interface IMovement
{
    void Move(ref Vector3 direction, Transform cameraTransform);
}