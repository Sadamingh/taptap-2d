using UnityEngine;

public class CubeSpin : MonoBehaviour
{
    public float rotationSpeedX = 30f;
    public float rotationSpeedY = 45f;
    public float rotationSpeedZ = 60f;

    void Update()
    {
        // Rotate the cube around the X, Y, and Z axes
        transform.Rotate(rotationSpeedX * Time.deltaTime, rotationSpeedY * Time.deltaTime, rotationSpeedZ * Time.deltaTime);
    }
}
