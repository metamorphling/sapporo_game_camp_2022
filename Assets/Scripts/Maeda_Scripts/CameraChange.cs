using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    private GameObject PlayerCamera;      //player側のカメラ格納用
    private GameObject EnemyCamera;      //player側のカメラ格納用
    private GameObject MidCamera;       //中央のカメラ格納用 

    private int Change = 0;

    //呼び出し時に実行される関数
    void Start()
    {
        //メインカメラとサブカメラをそれぞれ取得
       PlayerCamera = GameObject.Find("PlayerCastle Camera");
        EnemyCamera = GameObject.Find("EnemyCastle Camera");
        MidCamera = GameObject.Find("Mid Camera");

        //サブカメラを非アクティブにする
        EnemyCamera.SetActive(false);
        MidCamera.SetActive(false);
    }
    

    //単位時間ごとに実行される関数
    void Update()
    {
        //スペースキーが押されている間、サブカメラをアクティブにする
        if (Input.GetKeyDown("space"))
        {
            Change++;
        }
        if (Change == 0)
        {
            PlayerCamera.SetActive(true);
            EnemyCamera.SetActive(false);
        }
        if (Change == 1)
        {
            PlayerCamera.SetActive(false);
            MidCamera.SetActive(true);
        }
        if (Change == 2)
        {
            MidCamera.SetActive(false);
            EnemyCamera.SetActive(true);
        }
        if(Change == 3)
        {
            Change = 0;
        }
    }
}
