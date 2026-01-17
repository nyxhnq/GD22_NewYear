using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector2 offset;
    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] float rotationSpeed = 5f;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 desiredPosition = player.TransformPoint(offset);
        Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        Quaternion desiredRotation = Quaternion.LookRotation(player.forward, Vector2.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }

}