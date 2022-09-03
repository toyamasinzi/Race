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
        //�u�[�X�g
        if (_nc._nitroCheck && _check)
        {
            _nc._speed = _boost;
        }

        //�j�g���Q�[�W�����炷����
        if (_nitroGauge > _gaugeCheck && _check)
        {
            _nitroGauge -= Time.deltaTime;
        }
        //�j�g���Q�[�W���񕜂��鏈��
        else if (_nitroGauge < 0 && _nitroGauge > _maxGauge)
        {
            _nitroGauge += Time.deltaTime;

        }
        //�j�g���Q�[�W���I�[�o�[�q�[�g�������̏���
        if(_nitroGauge <= _maxGauge && _check == false)
        {
            _check = true;
        }
    }
}


