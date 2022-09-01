using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour
{
    private Car _nc;
    public bool _check = false;
    [SerializeField] float _boost = 8f;
    [SerializeField] float _nitroGauge = 10f;
    [SerializeField] float _gaugeCheck = 0.1f;
    [SerializeField] float _maxGauge = 10f;
    void Start()
    {
     
        _nc = FindObjectOfType<Car>();
    }

    void Update()
    {
        Boost();
    }
    void Boost()
    {
        if (_nc._nitroCheck && _check)
        {
            _nc._speed = _boost;
            if (_nitroGauge > _gaugeCheck)
            {
                _check = false;
                _nitroGauge -= Time.deltaTime;
            }
        }
        else if (_nc._nitroCheck == false)
        {
            if(_nitroGauge < _gaugeCheck)
            {
                _check = true;
            }
            else
            {
                return;
            }

        }
        else
        {
            _nc._speed += _nc._vInput * Time.deltaTime * _nc._moveSpeed;
        }

        if (_nitroGauge < 0 && _nitroGauge > _maxGauge)
        {
            _nitroGauge += Time.deltaTime;

        }
    }
}


