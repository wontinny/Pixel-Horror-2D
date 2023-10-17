using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private Transform _playerTransform;
    
    private float _timer;
    private float _timeBetweeenShots = 2f;

    private float _bulletSpeed = 2f;
    private float _exitTimer;
    private float _timeTillExit = 2f;
    private float _distanceToCountExit = .5f;

    
    public EnemyAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        //enemy.MoveEnemy(Vector2.zero);

        if (_timer > _timeBetweeenShots)
        {
            _timer = 0f;

            Vector2 dir = (_playerTransform.position - enemy.transform.position).normalized;

            Rigidbody2D web = GameObject.Instantiate(enemy.spiderWeb, enemy.transform.position, Quaternion.identity);
            web.velocity = dir * _bulletSpeed;
        }

        if (Vector2.Distance(_playerTransform.position, enemy.transform.position) > _distanceToCountExit)
        {
            _exitTimer += Time.deltaTime;

            if(_exitTimer > _timeTillExit)
            {
                enemy.StateMachine.ChangeState(enemy.ChaseState);
            }
        }
        else
        {
            _exitTimer = 0f;
        }

        _timer += Time.deltaTime;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
