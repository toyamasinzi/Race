using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour
{
    private Car _nc;
    [SerializeField] float _boost = 8f;
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
        if (_nc._nitroCheck == true)
        {
            _nc._speed = _boost;
        }
       /* else
        {
            _nc._speed = 0f;
        }*/
    }

}


