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
        //ブースト
        if (_nc._nitroCheck && _check)
        {
            _nc._speed = _boost;
        }

        //ニトロゲージを減らす処理
        if (_nitroGauge > _gaugeCheck && _check)
        {
            _nitroGauge -= Time.deltaTime;
        }
        //ニトロゲージを回復する処理
        else if (_nitroGauge < 0 && _nitroGauge > _maxGauge)
        {
            _nitroGauge += Time.deltaTime;

        }
        //ニトロゲージがオーバーヒートした時の処理
        if(_nitroGauge <= _maxGauge && _check == false)
        {
            _check = true;
        }
    }
}


