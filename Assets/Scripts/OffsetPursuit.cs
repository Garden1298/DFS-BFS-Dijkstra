using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPursuit : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public GameObject _target;

    //리더와의 거리
    public float _distanceOffset = 3.0f;
    public float _speed = 1.0f;
    public float _seekStrength = 1.0f;

    //private Vector3 _targetPosition = Vector3.zero;
    private Vector3 _desiredVelocity = Vector3.zero;
    private Vector3 _currentVelocity = Vector3.zero;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //_targetPosition = _target.transform.position - _rigidbody.velocity.normalized * _distanceOffset;
        _desiredVelocity = seek(_target.transform.position);
        _currentVelocity = _rigidbody.velocity;

        Vector3 seekForce = _desiredVelocity.normalized * _seekStrength;
        Vector3 newVelocity = (_currentVelocity + seekForce).normalized * _speed;

        _rigidbody.velocity = newVelocity;
    }

    private Vector3 seek(Vector3 target)
    {
        _desiredVelocity = (target - transform.position).normalized * _speed;

        // y축의 값이 있을 수 있으므로, 최초에 0으로 만들어 y축의 값을 사용하지 않도록 한다.
        _desiredVelocity.y = 0.0f;

        return _desiredVelocity - _currentVelocity;
    }
}
