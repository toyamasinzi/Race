using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �g���K�[�ɓ���ƃA�j���[�V�������Đ�����
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