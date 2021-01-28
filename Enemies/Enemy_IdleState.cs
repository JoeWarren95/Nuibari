using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_IdleState : IdleState
{
    private Enemy enemy;

    //constructor
    public Enemy_IdleState(Enemy entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, Enemy enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }

        else if (isIdleTimeOver)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
