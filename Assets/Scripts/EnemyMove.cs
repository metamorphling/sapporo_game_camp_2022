using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody _rigidbody;
    public CapsuleCollider capsuleCollider;

    private void Start()
    {
        moveSpeed = 0.3f;
        _rigidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - moveSpeed);
    }
    private void FixedUpdate()
    {
        
    }
}
