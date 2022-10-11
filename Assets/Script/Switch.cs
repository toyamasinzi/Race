using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// トリガーに入るとアニメーションを再生する
/// </summary>
public class Switch : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] string _animStateName = "";

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _animator.Play(_animStateName);
        }
    }
}