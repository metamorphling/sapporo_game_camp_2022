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

    public AudioClip Attack;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            if (gameObject.tag == "Enemy")
            {
                var info = gameObject.GetComponent<CharacterParameters>();
                if (info.Parameters.DropResource == ResourceType.Stone)
                {
                    GameManager.Instance.AddStone(info.Parameters.DropAmmount);
                }
                else if (info.Parameters.DropResource == ResourceType.Tree)
                {
                    GameManager.Instance.AddTree(info.Parameters.DropAmmount);
                }
                else if (info.Parameters.DropResource == ResourceType.Random)
                {
                    if (Random.Range(0, 2) == 1)
                    {
                        GameManager.Instance.AddTree(info.Parameters.DropAmmount);
                    }
                    else
                    {
                        GameManager.Instance.AddStone(info.Parameters.DropAmmount);
                    }
                }
            }
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
                _anim.SetBool(hashAttak, false);
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
                    audioSource.PlayOneShot(Attack);
                    attackCooldown = 0;
                    if (attackTarget == null)
                    {
                        return;
                    }
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
                }
            }
        }
    }
    private void FixedUpdate()
    {

    }
}