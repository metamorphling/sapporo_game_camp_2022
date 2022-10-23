using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawSpawn : MonoBehaviour
{
    [SerializeField]Camera mainCamera;
    [Header("スポーンキャラクターの登録")] [SerializeField]List<GameObject> charas = new List<GameObject>(3);
    [Header("キャラクター選択限界数")] [SerializeField]int selectLimit;
    [SerializeField]List<GameObject> selectedCharas;
    [Header("スポーン間隔（マウスカーソルの距離）")] [SerializeField]float spawnInterval;
    // public UnityEngine.UI.Image Icon1;
    // public UnityEngine.UI.Image Icon2;
    // public UnityEngine.UI.Image Icon3;
    Vector3 spawnedPosition;
    public UnityEngine.UI.Image[] Icons;
    [SerializeField] Color[] intiColor;
    [SerializeField] Color[] selectedColor;
    private List<bool> ActiveList = new List<bool> {false, false, false};
    int spawnindex = 0;
    bool isSpawned;
    public AudioClip Spawn;
    AudioSource audioSource;

    private void Awake()
    {
        Icons[0].color = intiColor[0];
        Icons[1].color = intiColor[1];
        Icons[2].color = intiColor[2];
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //mainCamera = Camera.main;
        // 未選択時のカラーを格納
        for(int i=0; i<Icons.Length; i++)
        {
            intiColor[i] = Icons[i].color;
        }
    }
 
    void Update()
    {
        // if (Input.GetMouseButton(0)) 
        // {
            
        //     var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        //     var raycastHitList = Physics.RaycastAll(ray).ToList();
        //     if (raycastHitList.Any())
        //     {
        //         var distance = Vector3.Distance(mainCamera.transform.position, raycastHitList.First().point);
        //         var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
 
        //         currentPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        //         currentPosition.y = 0;
        //         Debug.Log(currentPosition);
        //     }
        // }

        SelectCharacters();
        {   //カラー変更
            Color activecolor = Color.white;
            Color inactivecolor = Color.white;
            inactivecolor.a = 0.3f;
            for (int i = 0; i < ActiveList.Count; i++)
            {
                Icons[i].color = ActiveList[i] ? Icons[i].color = activecolor : Icons[i].color = inactivecolor;
            }
        }
        Deselect();

        if(Input.GetMouseButton(0))
        {
            GenerateCharacter(GetMouseRaycastHitPosition());
        }
    }

    /// <summary>
    /// キャラクターセレクト関数
    /// </summary>
    void SelectCharacters()
    {
        if(selectedCharas.Count == selectLimit) return;

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Icons[0].color = selectedColor[0];
            selectedCharas.Add(charas[0]);
            ActiveList[0] = !ActiveList[0];
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Icons[1].color = selectedColor[1];
            selectedCharas.Add(charas[1]);
            ActiveList[1] = !ActiveList[1];
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Icons[2].color = selectedColor[2];
            selectedCharas.Add(charas[2]);
            ActiveList[2] = !ActiveList[2];
        }
    }

    /// <summary>
    /// 選択解除
    /// </summary>
    void Deselect()
    {
        if(selectedCharas.Count == 0) return;

        if(Input.GetKeyDown(KeyCode.Alpha1) && selectedCharas.Count() == 1)
        {
            //Icons[0].color = Icons[0].color == intiColor[0] ? color : intiColor[0];
            selectedCharas.Add(charas[0]);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2) /*&& selectedCharas.Count() == 2*/)
        {
            //Icons[1].color = Icons[1].color == intiColor[1] ? color : intiColor[1];
            selectedCharas.Add(charas[1]);
            Debug.Log("選択解除 index1");
        }

        if(Input.GetKeyDown(KeyCode.Alpha3) /*&& selectedCharas.Count() == 3*/)
        {
            //Icons[2].color = Icons[2].color == intiColor[2] ? color : intiColor[2];
            selectedCharas.Add(charas[2]);
            Debug.Log("選択解除 index2");
        }
    }

    /// <summary>
    /// マウスのポジションを受け取る
    /// </summary>
    /// <returns>マウスポジション</returns>
    Vector3 GetMouseRaycastHitPosition()
    {
        var currentPosition = Vector3.zero;
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        var raycastHitList = Physics.RaycastAll(ray).ToList();
        if (raycastHitList.Any())
        {
            var distance = Vector3.Distance(mainCamera.transform.position, raycastHitList.First().point);
            var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);

            currentPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            currentPosition.y = 0;
        }

        return currentPosition;
    }

    /// <summary>
    /// キャラクターの生成
    /// </summary>
    void GenerateCharacter(Vector3 spawnPosition)
    {
        // キャラがセレクトされていない場合リターン
        if(selectedCharas.Count() == 0)
        {
            spawnindex = 0;
            return;
        }

        if(isSpawned)
        {
            var mouseMovePos = GetMouseRaycastHitPosition();
            var mouseInterval = Mathf.Abs(mouseMovePos.sqrMagnitude - spawnedPosition.sqrMagnitude);
            
            if (mouseInterval > spawnInterval)
            {
                isSpawned = false;
            }
        }
        else
        {
            if (Game.Players != null && Game.Players.Length > 2)
            {
                return;
            }
            var obj = Instantiate(selectedCharas[0], spawnPosition, Quaternion.identity);
            audioSource.PlayOneShot(Spawn);
            var param = obj.GetComponent<CharacterParameters>();
            if (param)
            {
                param.Init(true, 0);
            }
            Icons[0].color = intiColor[0];
            selectedCharas.RemoveAt(0); // 生成されたキャラクターを削除
            isSpawned = true;
            spawnedPosition = GetMouseRaycastHitPosition(); // 生成されたポジションを格納
        }
    }
 
    // void OnDrawGizmos()
    // {
    //     if (currentPosition != Vector3.zero)
    //     {
    //         Gizmos.color = Color.blue;
    //         Gizmos.DrawSphere(currentPosition, 0.5f);
    //     }
    // }
}

// ScreenToWorldPoint ScreenPointToRay RaycastHit