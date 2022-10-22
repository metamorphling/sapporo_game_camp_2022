using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    private GameObject PlayerCamera;      //player���̃J�����i�[�p
    private GameObject EnemyCamera;      //player���̃J�����i�[�p
    private GameObject MidCamera;       //�����̃J�����i�[�p 

    private int Change = 0;

    //�Ăяo�����Ɏ��s�����֐�
    void Start()
    {
        //���C���J�����ƃT�u�J���������ꂼ��擾
       PlayerCamera = GameObject.Find("PlayerCastle Camera");
        EnemyCamera = GameObject.Find("EnemyCastle Camera");
        MidCamera = GameObject.Find("Mid Camera");

        //�T�u�J�������A�N�e�B�u�ɂ���
        EnemyCamera.SetActive(false);
        MidCamera.SetActive(false);
    }
    

    //�P�ʎ��Ԃ��ƂɎ��s�����֐�
    void Update()
    {
        //�X�y�[�X�L�[��������Ă���ԁA�T�u�J�������A�N�e�B�u�ɂ���
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
