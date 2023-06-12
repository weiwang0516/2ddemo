using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyBaseState
{
    public override void EnterState(Enemy enemy)
    {
        enemy.animState = 0;
        enemy.SwintchPoint();
    }

    public override void OnUpdate(Enemy enemy)
    {
        if (!enemy._animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            enemy.animState = 1;
            enemy.MoveMent();
        }
        if (Mathf.Abs(enemy.transform.position.x - enemy.targetPoint.position.x) < 0.05f)
        {
            enemy.SwintchPoint();
            enemy.TransitionToState(enemy.patrolState);
        }
        if (enemy.attackList.Count > 0)
        {
            enemy.TransitionToState(enemy.attackState);
        }

    }
}
