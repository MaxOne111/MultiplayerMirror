using UnityEngine;

public class KeyboardMovement : IMovement
{
    public void Move(ref Vector3 direction, Transform cameraTransform)
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        direction = forward * ver + right * hor; 
    }
}