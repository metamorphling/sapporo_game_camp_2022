using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody _rigidbody;
    public CapsuleCollider capsuleCollider;
    public float AttackRange;
    public bool IsPlayer;

    Vector3 tmpVec;
    float distance;

    private void Start()
    {
        moveSpeed = 1.0f;
        _rigidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
#if DEBUG
        AttackRange = 15;
#endif
    }
    private void Update()
    {
        tmpVec = this.gameObject.transform.position;
        GameObject[] targets;
        if (IsPlayer)
        {
            targets = Game.Enemies;
        }
        else
        {
            targets = Game.Players;
        }

        if (targets != null && targets.Length > 0)
        {
            GameObject attackTarget = null;
            float minDistance = 999999999;
            foreach (var target in targets)
            {
                distance = Vector3.Distance(tmpVec, target.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    attackTarget = target;
                }
            }
            if (minDistance > AttackRange)
            {
                tmpVec = Vector3.MoveTowards(tmpVec, attackTarget.transform.position, moveSpeed);
                this.gameObject.transform.position = tmpVec;
            }
        }
    }
    private void FixedUpdate()
    {

    }
}