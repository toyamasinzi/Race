using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private bool _measurement = false;
    private bool _dirRt = false;
    public bool _nitroCheck = false;

    public float _speed = 0f;
    private float _maxSpeed = 5f;
    private float _leftRt = 0f;
    private float _rightRt = 0f;
    private float _v = 0f;
    [SerializeField] float _nitroGauge = 0f;
    [SerializeField] float _gaugeCheck = 10f;
    [SerializeField] float _rtSpeed = 0.5f;

    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Move();
        Nitro();
    }
    void Move()
    {
        _v = Input.GetAxisRaw("Vertical");

        if (_v != 0 && _measurement == false)
        {
            if (_speed < _maxSpeed)
            {
                _speed += _v * Time.deltaTime;
            }
        }
        else
        {
            _speed = 0f;
        }

        _rb.velocity = transform.forward * _speed;

        if (Input.GetKey("a"))
        {
            _dirRt = true;
            if (_dirRt)
            {
                _leftRt -= Time.deltaTime * _rtSpeed;
            }
            transform.Rotate(0, _leftRt, 0);
        }
        else
        {
            _leftRt = 0f;
            _dirRt = false;
        }

        if (Input.GetKey("d"))
        {
            _dirRt = true;
            if (_dirRt)
            {
                _rightRt += Time.deltaTime * _rtSpeed;
            }
            transform.Rotate(0, _rightRt, 0);
        }
        else
        {
            _dirRt = false;
            _rightRt = 0f;
        }
    }
    void Nitro()
    {
        if (_nitroGauge < _gaugeCheck)
        {
            _nitroGauge += Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            _nitroCheck = true;
        }
    }
}
