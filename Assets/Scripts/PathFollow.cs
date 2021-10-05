using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    [SerializeField]
    private Vector3[] _waypoints;

    [SerializeField]
    private float _speed = 2.0f;

    [SerializeField]
    private float _waypointRange = 1.3f;

    [SerializeField]
    //seek할 강도
    private float _seekStrength = 10.0f;

    private Rigidbody _rigidbody;

    private int _currentPointIndex = 1;

    private Vector3 _desiredVelocity = Vector3.zero;

    private Vector3 currentVelocity = Vector3.zero;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    public void pathfollow()
    {
        Vector3 targetPosition = _waypoints[_currentPointIndex];

        _desiredVelocity = seek(_waypoints[_currentPointIndex]);

        //현재 속도
        Vector3 currentVelocity = _rigidbody.velocity;

        //조종힘
        Vector3 seekForce = _desiredVelocity.normalized * _seekStrength;

        _rigidbody.velocity = (currentVelocity + seekForce).normalized * _speed;

        if (Vector3.Distance(targetPosition, gameObject.transform.position) < _waypointRange)
        {
            _currentPointIndex++;
        }
    }

    private Vector3 seek(Vector3 target)
    {
        _desiredVelocity = (target - transform.position).normalized * _speed;

        // y축의 값이 있을 수 있으므로, 최초에 0으로 만들어 y축의 값을 사용하지 않도록 한다.
        _desiredVelocity.y = 0.0f;

        return _desiredVelocity - currentVelocity;
    }
}
