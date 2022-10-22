using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody _rigidbody;
    public CapsuleCollider capsuleCollider;
    Vector3 tmpVec;
    float distans;
    private void Start()
    {
        moveSpeed = 1.0f;
        _rigidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }
    private void Update()
    {
        tmpVec = this.gameObject.transform.position;
        var target = GameObject.FindGameObjectsWithTag("Player");

        if (target.Length > 0)
        {
            distans = Vector3.Distance(tmpVec, target[0].transform.position);
            if (distans > 15)
            {
                tmpVec = Vector3.MoveTowards(tmpVec, target[0].transform.position, moveSpeed);
                this.gameObject.transform.position = tmpVec;
                //this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                //target[0].transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z );
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed);
        }
    }
    private void FixedUpdate()
    {
        
    }
}
