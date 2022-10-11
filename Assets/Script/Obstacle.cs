using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オブジェクトに当たるとスピードを減らす
/// </summary>
public class Obstacle : MonoBehaviour
{
    private CarMove _carMove;
    private GameObject _car;
    [SerializeField] float _speed = 10f;

    void Start()
    {
        _car = GameObject.Find("Player");
        _carMove = _car.GetComponent<CarMove>();
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && _carMove.Speed > _speed)
        {
            _carMove.Speed -= _speed;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && _carMove.Speed >_speed)
        {
            _carMove.Speed -= _speed;
        }
    }
}
