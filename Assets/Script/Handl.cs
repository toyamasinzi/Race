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

        // 入力方向のベクトルを組み立てる
       // Vector3 dir = Vector3.forward * v + Vector3.right * h;
        Vector3 dir = Vector3.right * h;

        if (dir  != Vector3.zero)
        {
            // カメラを基準に入力が上下=奥/手前, 左右=左右にキャラクターを向ける
            dir = Camera.main.transform.TransformDirection(dir);    // メインカメラを基準に入力方向のベクトルを変換する
            dir.y = 0;  // y 軸方向はゼロにして水平方向のベクトルにする

            // 入力方向に滑らかに回転させる
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * _slerp);
        }
    }
}
        
