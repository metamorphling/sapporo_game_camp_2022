using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [SerializeField]private GameObject PlayerCamera;      //player側のカメラ格納用
    [SerializeField]private GameObject EnemyCamera;      //player側のカメラ格納用
    [SerializeField]private GameObject MidCamera;       //中央のカメラ格納用 

    private int Change = 0;

    Vector3 MouseWheel;

    //呼び出し時に実行される関数
    void Start()
    {
        //メインカメラとサブカメラをそれぞれ取得
        
        //サブカメラを非アクティブにする
        EnemyCamera.SetActive(false);
        MidCamera.SetActive(false);
    }
    

    //単位時間ごとに実行される関数
    void Update()
    {
        MouseWheel.y += Input.mouseScrollDelta.y;
        
        //スペースキーが押されている間、サブカメラをアクティブにする
        if (MouseWheel.y == 1)
        {
            Change++;
            MouseWheel.y = 0;
        }
        if (MouseWheel.y == -1)
        {
            Change--;
            MouseWheel.y = 0;
        }
        if (Change == 0)
        {
            PlayerCamera.SetActive(true);
            MidCamera.SetActive(false);
            EnemyCamera.SetActive(false);
        }
        if (Change == 1 || Change == -2)
        {
            PlayerCamera.SetActive(false);
            MidCamera.SetActive(true);
            EnemyCamera.SetActive(false);
        }
        if (Change == 2 || Change == -1)
        {
            PlayerCamera.SetActive(false);
            MidCamera.SetActive(false);
            EnemyCamera.SetActive(true);
        }
        if (Change == 3 || Change == -3)
        {
            Change = 0;
        }
    }
}
