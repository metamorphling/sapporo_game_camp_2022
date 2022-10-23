using UnityEngine;

public class MoveController : MonoBehaviour
{
    enum ENEMY_STATE
    {
        SEARCH,
        ATTAKING,
        DEAD
    }
    public Rigidbody _rigidbody;
    public Collider capsuleCollider;
    public bool IsPlayer;
    public CharacterParameters Info;

    float distance;
    Animator _anim;//s
    ENEMY_STATE state;//s
    int hashAttak = Animator.StringToHash("IsAttack");//s
    float attackCooldown;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        _anim = this.GetComponent<Animator>();

        state = ENEMY_STATE.SEARCH; // プレイヤーを探索するステートに設定
    }
    private void Update()
    {
        if (Info == null || Info.IsInitialized == false)
        {
            return;
        }
        if (Info.CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
            return;
        }
        var position = _rigidbody.position;
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
            Vector3 targetPos = Vector3.zero;
            float distanceToEnemy = 999999999;
            foreach (var target in targets)
            {
                if (target == null)
                {
                    continue;
                }
                var targetMove = target?.GetComponent<MoveController>();
                if (targetMove)
                {
                    targetPos = targetMove._rigidbody.position;
                }
                var castle = target?.GetComponent<CastleController>();
                if (castle)
                {
                    targetPos = castle.RigidBody.position;
                }
                distance = Vector3.Distance(position, targetPos);
                if (distance < distanceToEnemy)
                {
                    distanceToEnemy = distance;
                    attackTarget = target;
                }
            }
            if (attackTarget != null && distanceToEnemy > Info.Parameters.AttackRange) // 攻撃範囲に入ってない場合
            {
                _rigidbody.MovePosition(position + (targetPos - position).normalized * Info.Parameters.MoveSpeed * Time.deltaTime);
            }
            else // 攻撃範囲に入ったとき
            {
                //攻撃、アニメーション
                state = ENEMY_STATE.ATTAKING;
                if (_anim)
                {
                    _anim.SetBool(hashAttak, true);
                }
                attackCooldown += Time.deltaTime;
                if (attackCooldown > Info.Parameters.AttackSpeed)
                {
                    attackCooldown = 0;
                    var charParams = attackTarget.GetComponent<CharacterParameters>();
                    if (charParams)
                    {
                        charParams.CurrentHealth -= Info.Parameters.Damage;
                    }
                    var castleParams = attackTarget.GetComponent<CastleParameters>();
                    if (castleParams)
                    {
                        castleParams.CurrentHealth -= Info.Parameters.Damage;
                    }
                    Debug.Log("Attack! ");
                }
            }
        }
    }
    private void FixedUpdate()
    {

    }
}