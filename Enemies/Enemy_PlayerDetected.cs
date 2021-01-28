using System.Collections;
using System.Collections.Generic;
using System.Management.Instrumentation;
using UnityEngine;

public class Enemy_PlayerDetected : PlayerDetectedState
{

    private Enemy enemy;

    //ManagementEntityAttribute
    public Enemy_PlayerDetected(Enemy entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Enemy enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        //state transition stuff
        base.LogicUpdate();

        if (!isPlayerInMaxAgroRange)
        {
            //so enemy doesn't flip if player runs away
            enemy.idleState.SetFlipAfterIdle(false);
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
