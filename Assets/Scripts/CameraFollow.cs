using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float followLerp;
    Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        FollowTarget();
        LookAtTarget();
    }

    void FollowTarget()
    {
        Vector3 followPos = target.position + offset;
        _camera.transform.position = Vector3.Lerp(transform.position, followPos, followLerp * Time.deltaTime);
    }

    void LookAtTarget()
    {
        Vector3 lookAtRotation = new Vector3( transform.position.x,target.position.y, target.position.z);
        _camera.transform.LookAt(lookAtRotation);
    }
}