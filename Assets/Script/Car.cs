using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private bool _measurement = false;
    private bool _dirRt = false;
    public bool _nitroCheck = false;

    public float _speed = 0f;
    private float _leftRt = 0f;
    private float _rightRt = 0f;
    private float _vInput = 0f;
    [SerializeField] float _moveSpeed = 0.5f;
    [SerializeField] float _maxSpeed = 5f;
    [SerializeField] float _nitroGauge = 0f;
    [SerializeField] float _gaugeCheck = 10f;
    [SerializeField] float _rtSpeed = 0.5f;
    [SerializeField] Transform _camera;

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
        _vInput = Input.GetAxisRaw("Vertical");
        Vector3 _dir = new Vector3(0, 0, _vInput);
        if (_vInput != 0 && _measurement == false)
        {
            if (_speed < _maxSpeed)
            {
                _speed += _vInput * Time.deltaTime * _moveSpeed;
            }
        }
        else
        {
            _speed = 0f;
        }

        _camera.transform.position = transform.position;
        // _rb.velocity = new Vector3(_camera.forward.x, _rb.velocity.y, _camera.forward.z) * _speed;
        Vector3 vec = Camera.main.transform.TransformDirection(_dir);
        vec.y = 0;
        vec = vec.normalized;
        _rb.velocity = vec * _speed;

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
            if (_nitroCheck == false)
            {
                _nitroCheck = true;
            }
            else
            {
                _nitroCheck = false;
            }
        }
    }
}
