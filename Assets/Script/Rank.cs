using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ŽžŠÔ‚É‰ž‚¶‚Äƒ‰ƒ“ƒN‚ðŒˆ‚ß‚é
/// </summary>
public class Rank : MonoBehaviour
{
    [SerializeField] GameObject _time;
    private string _s = "S";
    private string _a = "A"; 
    private string _b = "B";
    private string _c = "C";
    private string _d = "D";
    private float _timer;
    void Start()
    {
        _timer = Timer.getTime();
        gameObject.GetComponent<Text>();
    }

    void Update()
    {
        if(_timer < 65f)
        {
            _time.GetComponent<Text>().text = _s;
        }
        else if(_timer < 75f)
        {
            _time.GetComponent<Text>().text = _a;
        }
        else if(_timer < 85f)
        {
            _time.GetComponent<Text>().text = _b;
        }
        else if(_timer < 95f)
        {
            _time.GetComponent<Text>().text = _c;
        }
        else
        {
            _time.GetComponent<Text>().text = _d;
        }
    }
}
