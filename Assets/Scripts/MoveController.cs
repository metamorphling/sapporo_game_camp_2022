using UnityEngine;

public class MoveController : MonoBehaviour
{
    enum ENEMY_STATE
    {
        SEARCH,
        ATTAKING,
        DEAD
    }
    public float moveSpeed;
    public Rigidbody _rigidbody;
    public CapsuleCollider capsuleCollider;
    public float AttackRange;
    public bool IsPlayer;

    Vector3 tmpVec;
    float distance;
    Animator _anim;//s
    ENEMY_STATE state;//s
    int hashAttak = Animator.StringToHash("IsAttack");//s

    private void Start()
    {
        moveSpeed = 0.5f;
        _rigidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        _anim = this.GetComponent<Animator>();

        state = ENEMY_STATE.SEARCH; // プレイヤーを探索するステートに設定
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
            if (minDistance > AttackRange) // 攻撃範囲に入ってない場合
            {
                tmpVec = Vector3.MoveTowards(tmpVec, attackTarget.transform.position, moveSpeed);
                this.gameObject.transform.position = tmpVec;
            }
            else // 攻撃範囲に入ったとき
            {
                //攻撃、アニメーション
                state = ENEMY_STATE.ATTAKING;
                _anim.SetBool(hashAttak, true);
            }
        }
    }
    private void FixedUpdate()
    {

    }
}