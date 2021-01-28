using System;
using System.Collections;
using System.Collections.Generic;
//using System.Runtime.Remoting.Services;
using UnityEngine;

public class Enemy_MoveState : MoveState
{
    private Enemy enemy;

    public Enemy_MoveState(Enemy entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Enemy enemy) : base(entity, stateMachine, animBoolName, stateData)
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

        else if (isDetectingWall || !isDetectingLedge)
        {
            //flip this boi
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
