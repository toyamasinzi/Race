using UnityEngine;

public class Handl : MonoBehaviour
{
    [SerializeField] float _slerp = 0f;
   
    void Start()
    {
        
    }

    void Update()
    {
        Handling();
    }
    void Handling()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        // ���͕����̃x�N�g����g�ݗ��Ă�
       // Vector3 dir = Vector3.forward * v + Vector3.right * h;
        Vector3 dir = Vector3.right * h;

        if (dir  != Vector3.zero)
        {
            // �J��������ɓ��͂��㉺=��/��O, ���E=���E�ɃL�����N�^�[��������
            dir = Camera.main.transform.TransformDirection(dir);    // ���C���J��������ɓ��͕����̃x�N�g����ϊ�����
            dir.y = 0;  // y �������̓[���ɂ��Đ��������̃x�N�g���ɂ���

            // ���͕����Ɋ��炩�ɉ�]������
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * _slerp);
        }
    }
}
        
