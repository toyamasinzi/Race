using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 車のスピードと縦方向の動き
/// </summary>
public class CarMove : MonoBehaviour
{
    private float _hInput = 0f;
    private AudioSource _ad;
    private Rigidbody _rb;
    private int _count = 0;
    private float _wallCheck = 50f;

    [SerializeField] float _wallSpeed = 10f;
    [SerializeField] float _minusMoveSpeed = -10f;
    [SerializeField] AudioClip _se;
    [SerializeField] Text _speedText;
    [SerializeField] Transform _camera;
    [SerializeField] GameObject _Smoke;
    [SerializeField] float _rotateSpeed = 100;
    /// <summary>プロパティ/// </summary>
    private bool _nitroCheck = false;
    public bool NitroCheck {get => _nitroCheck; set => _nitroCheck = value;}
    private float _vInput = 0f;
    public float Vinput {get => _vInput;}
    private float _moveSpeed = 30f;
    public float MoveSpeed {get => _moveSpeed; set => _moveSpeed = value;}
    private float _maxSpeed = 100f;
    public float MaxSpeed {get => _maxSpeed; set => _maxSpeed = value;}
    private float _speed = 0f;
    public float Speed {get => _speed; set => _speed = value;}
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _ad = GetComponent<AudioSource>();
    }
    void Update()
    {
        Move();
        Nitro();
        Debug.Log(_moveSpeed);
        Debug.Log(MoveSpeed);
    }
    void Move()
    {
        _speedText.text = Mathf.Abs(_speed).ToString("000");//Mas.Abs　0からの絶対値をとる
        _vInput = Input.GetAxisRaw("Vertical");
        _hInput = Input.GetAxisRaw("Horizontal");

        transform.Rotate(0, _hInput, 0);
        if (_vInput != 0)
        {
            _Smoke.SetActive(true);
            if (_speed < _maxSpeed && _vInput == 1)
            {
                _speed += _vInput * Time.deltaTime * _moveSpeed;
                _count = 0;
            }
            else if(_speed > _minusMoveSpeed && _vInput == -1)
            {
                if (_speed > _moveSpeed && _count == 0)
                {
                    _speed -= 30;
                    _count++;
                }
                _speed += _vInput * Time.deltaTime * _moveSpeed;
            }
        }
        else//減速する処理
        {
            _Smoke.SetActive(false);
            if (_speed > 0)
            {
                _speed -= Time.deltaTime * _moveSpeed;
            }
            else if (_speed < 0)
            {
                _speed += Time.deltaTime * _moveSpeed;
            }
        }
        _rb.velocity = transform.forward * _speed;
    }
    void Nitro()
    {

        if (Input.GetButtonDown("Jump"))
        {

            if (_nitroCheck == false)
            {
                _nitroCheck = true;
                _ad.PlayOneShot(_se);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall" && _speed > _wallCheck)
        {
            _speed -= _wallSpeed;
        }
    }
}

