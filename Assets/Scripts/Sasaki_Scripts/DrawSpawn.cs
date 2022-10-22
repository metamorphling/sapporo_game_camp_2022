using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawSpawn : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField]GameObject charas;
    [SerializeField]float spawnedInterval;
    Vector3 spawnedPosition;
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

        if(Input.GetMouseButton(0))
        {
            GenerateCharacter(GetMouseRaycastHitPosition());
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
        //Debug.Log();
        if(isSpawned)
        {
            var mouseMoveVelo = GetMouseRaycastHitPosition();
            if(spawnedPosition.sqrMagnitude > spawnedInterval * spawnedInterval)
            {
                isSpawned = false;
            }
        }
        else
        {
            var obj = Instantiate(charas, spawnPosition, Quaternion.identity);
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