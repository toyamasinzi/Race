using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 別のシーンでタイムを表示する
/// </summary>
public class KeepTime : MonoBehaviour
{
    [SerializeField] GameObject _kptm;
    private float _nowTime;
   
    void Start()
    {
        _nowTime = Timer.getTime();
        gameObject.GetComponent<Text>();
    }
    private void Update()
    {
        _kptm.GetComponent<Text>().text = _nowTime.ToString("F1");
    }
}