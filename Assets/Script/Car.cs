using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private float _maxSpeed = 5f;
    [SerializeField] float _speed = 0f;
    private bool _nitroCheck = false;
    private bool _measurement = false;
    private Rigidbody _rb;
    private float _leftRt = 0f;
    private float _rightRt = 0f;
    private float v = 0f;
    private float h = 0f;
    private Vector3 _dir = new Vector3(0, 0, 0);

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        v = Input.GetAxisRaw("Vertical");

        if (v != 0 && _measurement == false)
        {
            if (_speed < _maxSpeed)
            {
                _speed += Time.deltaTime;
            }
        }
        else
        {
            _speed = 0f;
        }

        if (Input.GetKey("a"))
        {
            _leftRt -= Time.deltaTime;
            transform.Rotate(0, _leftRt, 0);
        }
        else
        {

        }
        if (Input.GetKey("d"))
        {
            _rightRt += Time.deltaTime;
            transform.Rotate(0, _rightRt, 0);
        }

        _rb.velocity = _dir.normalized * _speed;

    }
}
