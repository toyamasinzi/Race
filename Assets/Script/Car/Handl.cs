using UnityEngine;

public class Handl : MonoBehaviour
{
    [SerializeField] float _slerp = 0f;
    [SerializeField] float _speed = 0f;
   
    void Start()
    {
        
    }

    void Update()
    {
        Handling();
    }
    void Handling()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 dir = Vector3.right * h;

        if (dir  != Vector3.zero)
        {
            // �J��������ɓ��͂��㉺=��/��O, ���E=���E�ɃL�����N�^�[��������
            dir = Camera.main.transform.TransformDirection(dir);
            dir.y = 0;  // y �������̓[���ɂ��Đ��������̃x�N�g���ɂ���

            // ���͕����Ɋ��炩�ɉ�]������
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _speed * _slerp);
        }
    }
}
        
