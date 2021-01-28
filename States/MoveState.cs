using System.Collections;
using System.Collections.Generic;
using System.Management.Instrumentation;
using UnityEngine;

public class MoveState : State
{
    protected D_MoveState stateData;

    protected bool isDetectingWall;
    protected bool isDetectingLedge;

    protected bool isPlayerInMinAgroRange;

    public MoveState(Enemy entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        //the base is added bc we're using code from our original Enter() function
        //if we wanted to change it completely, remove the base and add new code
        base.Enter();

        //EnemyBase.SetVelocity(moveSpeed);

        entity.SetVelocity(stateData.moveSpeed);

        //is there a wall or ledge in front of me? (should also be in PhysicsUpdate)
        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
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
            stateMachine.ChangeState(entity.playerDetectedState);
        }

        else if(isDetectingWall || isDetectingLedge)
        {
            //enemy.idleState.SetFlipAfterIdle(true);
            entity.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(entity.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }
}
