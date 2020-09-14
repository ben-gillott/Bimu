using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Objects")]
    [Tooltip("Target to snap to")]
    public Transform target; //Player

    [Header("Variables")]
    [Tooltip("Higher value -> faster lock on")]
    public float smoothSpeed = 0.125f; 
    public Vector3 offset;

    void LateUpdate() {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        //Look at where the player currently is
        // transform.LookAt(target);
    }

}
