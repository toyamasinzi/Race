using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

/// <summary>
/// ŽžŠÔŒv‘ª
/// </summary>
public class Timer : MonoBehaviour
{
    [SerializeField] GameObject _scene;
    private GameScene _stop;
    public static float _CountTime;
    private Text _text;
    void Start()
    {
        _text = gameObject.GetComponent<Text>();
        _scene = GameObject.Find("Player");
        _stop = _scene.GetComponent<GameScene>();
        _CountTime = 0;
    }

    void Update()
    {
        if (_stop.Stop == false)
        {
            _CountTime += Time.deltaTime;
             _text.text = _CountTime.ToString("F1");
        }
    }
    public static float getTime()
    {
        return _CountTime;
    }
}


