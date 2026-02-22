using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;   // player
    public float smoothSpeed = 5f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = transform.position.z; // keep camera Z

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );
    }
}
