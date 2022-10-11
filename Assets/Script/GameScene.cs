using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    [SerializeField] string _scene;
    private bool _stop = false;
    public bool Stop
    {
        get => _stop;
        set => _stop = value;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Goal")
        {
            _stop = true;
            SceneManager.LoadScene(_scene);
        }
    }
}