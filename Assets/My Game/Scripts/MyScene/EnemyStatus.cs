using System.Collections;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 敵の状態管理スクリプト
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyStatus : MobStatus
{
    public float enemyLifetime = 120f;
    private NavMeshAgent _agent;

    protected override void Start()
    {
        base.Start();

        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // NavMeshAgentのvelocityで移動速度のベクトルが取得できる
        _animator.SetFloat("MoveSpeed", _agent.velocity.magnitude);
    }

    public override void OnDie()
    {
        base.OnDie();
        StartCoroutine(DestroyCoroutine());
    }

    /// <summary>
    /// 倒された時の消滅コルーチンです。
    /// </summary>
    /// <returns></returns>
    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);

        // 死亡時の座標
        Vector3 deathPosition = transform.position;

    }


    /// <summary>
    /// 自然消滅コルーチンです。生成時(CreateEnemy)にコルーチンを始動させます。
    /// </summary>
    public IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(enemyLifetime);
        //Debug.Log(transform.root.gameObject + " destroyed!");
        Destroy(transform.root.gameObject);
    }
}