using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// 車のブースト
/// </summary>
public class Nitro : MonoBehaviour
{
    private CarMove _nc;
    private bool _dawnCheck = false;
    private float _nPV = 0f;
    private float _reduceSpeed = 50f;
    private float _move = 0f;

    [SerializeField] Slider _slider = default;
    [SerializeField] GameObject _turbo;
    [SerializeField] float _time = 0.5f;
    [SerializeField] float _limitBreak = 300f;
    [SerializeField] float _boost = 100;
    [SerializeField] float _nitroGauge = 10f;
    [SerializeField] float _gaugeCheck = 0.1f;
    [SerializeField] float _maxGauge = 10f;

    void Start()
    {
        _slider.maxValue = _nitroGauge;
        _slider.value = _nitroGauge;
        _nc = FindObjectOfType<CarMove>();
        _nPV = _nc.MaxSpeed;
        _move = _nc.MoveSpeed;
    }

    void Update()
    {
        Boost();
    }
    void Boost()
    {
        //ブースト
        if (_nc.NitroCheck)
        {
            _nc.MaxSpeed = _limitBreak;
            _nc.MoveSpeed = _boost;
            _nitroGauge -= Time.deltaTime;
            Gauge(_slider.value -= Time.deltaTime);
            if (_nc.Vinput != 0)
            {
                _turbo.SetActive(true);
            }
            else
            {
                _turbo.SetActive(false);
            }

            if (_nitroGauge <_gaugeCheck)
            {
                _nc.NitroCheck = false;
                _dawnCheck = true;
            }
        }
        else//ゲージ回復
        {
            if(_nitroGauge < _maxGauge)
            {
                _nitroGauge += Time.deltaTime;
                Gauge(_slider.value += Time.deltaTime);
            }
        }

        if (_dawnCheck && _nc.MaxSpeed > _nPV && _nc.NitroCheck == false)//減速する処理
        {
            _turbo.SetActive(false);
            _nc.MaxSpeed -= Time.deltaTime * _reduceSpeed;
            _nc.Speed -= Time.deltaTime * _reduceSpeed;
            _nc.MoveSpeed = _move;
        }
    }
    void Gauge(float value)
    {
        DOTween.To(() => _slider.value, x => _slider.value = x, value, _time);
    }
}


