using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オブジェクトを回転させる
/// </summary>
public class Rotate : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 360) * Time.deltaTime);//360度回転
    }
}