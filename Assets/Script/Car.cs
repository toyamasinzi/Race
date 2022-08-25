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
    float v = 0f;
    float h = 0f;
    private Vector3 dir = new Vector3(0, 0, 0);

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        v = Input.GetAxisRaw("Vertical");

        if (v != 0 && _measurement == false)
        {
            if( _speed < _maxSpeed)
            {
                _speed += Time.deltaTime;
            }
        }
        else 
        {
            _speed = 0f;
        }

        dir = new Vector3(0, 0, v);
        _rb.velocity = dir.normalized * _speed;

    }
}
