using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera _camera;
    Transform _target;
    Vector3 _offset;

    float _followLerp;

    public void Init(Camera cam, Transform target, Vector3 offset, float followLerp = 8f)
    {
        _camera = cam;
        _target = target;
        _offset = offset;
        _followLerp = followLerp;
    }

    void Update()
    {
        FollowTarget();
        LookAtTarget();
    }

    void FollowTarget()
    {
        Vector3 followPos = _target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, followPos, _followLerp * Time.deltaTime);
    }

    void LookAtTarget()
    {
        Vector3 lookAtRotation = new Vector3( transform.position.x,_target.position.y, _target.position.z);
        transform.LookAt(lookAtRotation);
    }
}