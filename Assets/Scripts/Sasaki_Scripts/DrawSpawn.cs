using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSpawn : MonoBehaviour
{
GameObject vertex;
GameObject parent;
GameObject nowParent = null;
Vector3 lastPos;

void Start () 
{
    lastPos = this.transform.position;
}


void Update () {

    // if (Input.GetMouseButtonDown(0)) {
    //     CreateEmpty();
    // }

    // if (Input.GetMouseButton(0)) {
    //     DrawLine();
    // }

    // if (Input.GetMouseButtonUp(0)) {
    //     nowParent.AddComponent<Rigidbody>();
    //     nowParent = null;
    // }

}

// void CreateEmpty() {
//     var pos = Input.mousePosition;
//     var ray = Camera.main.ScreenPointToRay (pos);
//     var hit = RaycastHit;
//     if (Physics.Raycast (ray, hit, 100)) {
//         var target = hit.point;
//         target.z = 2;
//         nowParent = Instantiate (parent, target, transform.rotation);
//         nowParent.transform.parent = gameObject.transform;
//     }    
// }

// void DrawLine() {
//     var pos = Input.mousePosition;
//     if (pos == lastPos) {
//         return;
//     }
//     var ray = Camera.main.ScreenPointToRay (pos);
//     RaycastHit hit;
//     if (Physics.Raycast (ray, hit))
//     {
//         var target = hit.point;
//         target.z = 2;
//         var obj = Instantiate (vertex, target, transform.rotation);
//         obj.transform.parent = nowParent.transform;
//         lastPos = pos;
//     }
// }
}
