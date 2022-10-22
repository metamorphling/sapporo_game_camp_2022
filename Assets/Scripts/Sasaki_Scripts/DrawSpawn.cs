using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawSpawn : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 currentPosition = Vector3.zero;
    [SerializeField]GameObject charas;
 
    void Start()
    {
        mainCamera = Camera.main;
    }
 
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            var raycastHitList = Physics.RaycastAll(ray).ToList();
            if (raycastHitList.Any()) {
                var distance = Vector3.Distance(mainCamera.transform.position, raycastHitList.First().point);
                var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
 
                currentPosition = mainCamera.ScreenToWorldPoint(mousePosition);
                currentPosition.y = 0;
                Debug.Log(currentPosition);
                var obj = Instantiate(charas, currentPosition, Quaternion.identity);
            }
        }
    }
 
    void OnDrawGizmos()
    {
        if (currentPosition != Vector3.zero) {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(currentPosition, 0.5f);
        }
    }
}

// ScreenToWorldPoint ScreenPointToRay RaycastHit