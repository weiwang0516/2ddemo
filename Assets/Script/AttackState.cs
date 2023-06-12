using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : EnemyBaseState
{
    public override void EnterState(Enemy enemy)
    {
        enemy.animState = 2;
        enemy.targetPoint =enemy.attackList[0];
    }

    public override void OnUpdate(Enemy enemy)
    {
        if (enemy.attackList.Count == 0) //当没有遇到物体时 切换为巡逻状态
        {
            enemy.TransitionToState(enemy.patrolState);
        }
        if (enemy.attackList.Count > 1) //当有一个物体以上时 判断哪个物体离enemy近 就跟随哪个物体  enemy.targetPoint.position.x这个为 enemy.targetPoint = enemy.attackList[0];
        {
            for (int i = 0; i < enemy.attackList.Count; i++)
            {
                if (Mathf.Abs(enemy.transform.position.x - enemy.attackList[i].position.x) <
                    Mathf.Abs(enemy.transform.position.x - enemy.targetPoint.position.x))
                {
                    enemy.targetPoint = enemy.attackList[i];
                }
            }
        }
        enemy.MoveMent();
    }
}
