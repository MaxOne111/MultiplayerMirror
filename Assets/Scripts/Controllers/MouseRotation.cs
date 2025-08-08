using UnityEngine;

public class MouseRotation : IRotation
{
    private Transform _transform;
    
    public MouseRotation(Transform transform)
    {
        _transform = transform;
    }

    public void Rotate()
    {
        float axisX = Input.GetAxis("Mouse X");

        float currentAxisX = _transform.eulerAngles.y + axisX;

        currentAxisX %= 360f;

        _transform.rotation = Quaternion.Euler(0, currentAxisX, 0);
    }
}