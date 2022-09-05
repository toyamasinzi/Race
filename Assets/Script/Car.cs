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
    public float _vInput = 0f;
    public float _hInput = 0f;

    public float _moveSpeed = 0.5f;
    [SerializeField] float _maxSpeed = 5f;

    [SerializeField] float _rtSpeed = 0.5f;
    [SerializeField] Transform _camera;

    private Nitro _nitro;
    private Rigidbody _rb;
    void Start()
    {
        _nitro = FindObjectOfType<Nitro>();
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
        _hInput = Input.GetAxisRaw("Horizontal");


        transform.Rotate(0, _hInput, 0);
        //Vector3 _dir = new Vector3(0, 0, _vInput);// z����Vertical�̓��͂���
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
        _rb.velocity = transform.forward * _speed;
        //_rb.AddForce(_rb.mass * Vector3.right * _speed / Time.fixedDeltaTime, ForceMode.Force);


        //_camera.transform.position = transform.position;
        //// _rb.velocity = new Vector3(_camera.forward.x, _rb.velocity.y, _camera.forward.z) * _speed;
        //Vector3 vec = this.transform.right; //Camera.main.transform.TransformDirection(_dir);//�J���������[�J�����W���烏�[���h���W�ɕϊ����A����������͂��J������ɂ���
        //vec.y = 0;//y�����Œ�
        //vec = vec.normalized;//���x����艻
        //_rb.velocity = vec * _speed;//�ړ�


        //if (Input.GetKey("a"))//���ɉ�]
        //{
        //    _dirRt = true;
        //    if (_dirRt)
        //    {
        //        _leftRt -= Time.deltaTime * _rtSpeed;
        //    }
        //    transform.Rotate(0, _leftRt, 0);
        //}
        //else
        //{
        //    _leftRt = 0f;
        //    _dirRt = false;
        //}

        //if (Input.GetKey("d"))//�E�ɉ�]
        //{
        //    _dirRt = true;
        //    if (_dirRt)
        //    {
        //        _rightRt += Time.deltaTime * _rtSpeed;
        //    }
        //    transform.Rotate(0, _rightRt, 0);
        //}
        //else
        //{
        //    _dirRt = false;
        //    _rightRt = 0f;
        //}


        /*  float handle = GetHandleInput();
          transform.Rotate(0, handle * 25 * Time.deltaTime, 0);//�n���h���̋���������*/
    }
    void Nitro()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            _nitro._check = true;
            _nitroCheck = !_nitroCheck;
        }
    }

    /*float GetHandleInput()
    {
        if (Input.GetKey("a"))
        {
            return -1;
        }
        else if (Input.GetKey("d"))
        {
            return 1;
        }
        if(Input.GetAxis("Horizontal"))
        {
          
        }
        return 0;*/
}

