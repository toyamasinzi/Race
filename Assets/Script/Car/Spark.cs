using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour
{
    private ParticleSystem _spark;
    void Start()
    {
        _spark = GetComponentInChildren<ParticleSystem>();
    }
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag != "Trigger")
        {
            _spark.Play();
        }
    }
}
