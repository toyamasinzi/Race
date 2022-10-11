using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drift : MonoBehaviour
{
    [SerializeField] Transform _car;

    void Update()
    {
        AngleChange();
    }
    private void AngleChange()
    {
        if (Input.GetKeyDown("q"))
        {
            _car.Rotate(0,30, 0);
        }
        if(Input.GetKeyDown("e"))
        {
            _car.Rotate(0, -30, 0);
        }
    }
}
