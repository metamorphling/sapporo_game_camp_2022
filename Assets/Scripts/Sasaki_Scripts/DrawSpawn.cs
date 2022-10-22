using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawSpawn : MonoBehaviour
{
    private Camera mainCamera;
    [Header("スポーンキャラクターの登録")] [SerializeField]List<GameObject> charas;
    [Header("キャラクター選択限界数")] [SerializeField]int selectLimit;
    [SerializeField]List<GameObject> selectedCharas;
    [Header("スポーン間隔（マウスカーソルの距離）")] [SerializeField]float spawnInterval;
    Vector3 spawnedPosition;
    int spawnindex = 0;
    bool isSpawned;
 
    void Start()
    {
        mainCamera = Camera.main;
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

        if(Input.GetMouseButton(0))
        {
            GenerateCharacter(GetMouseRaycastHitPosition());
        }
    }

    void SelectCharacters()
    {
        if(selectedCharas.Count == selectLimit) return;

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedCharas.Add(charas[0]);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedCharas.Add(charas[1]);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedCharas.Add(charas[2]);
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
        if(selectedCharas.Count() == 0) return;

        if(isSpawned)
        {
            var mouseMovePos = GetMouseRaycastHitPosition();
            var mouseInterval = Mathf.Abs(mouseMovePos.sqrMagnitude - spawnedPosition.sqrMagnitude);
            if(mouseInterval > spawnInterval)
            {
                isSpawned = false;
            }
        }
        else
        {
            var obj = Instantiate(charas[spawnindex], spawnPosition, Quaternion.identity);
            if(spawnindex == selectedCharas.Count())
            {
                selectedCharas.Clear();
                spawnindex = 0;
            }
            spawnindex++;
            isSpawned = true;
            spawnedPosition = GetMouseRaycastHitPosition();
        }
        
        Debug.Log(spawnedPosition.sqrMagnitude);
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