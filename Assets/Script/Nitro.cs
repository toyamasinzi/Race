using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour
{
    private Car _nc;
    void Start()
    {
        _nc = FindObjectOfType<Car>();
    }

    void Update()
    {
        if(_nc._nitroCheck == true)
        {
            _nc._speed = 8f;
        }
    }
}
