using System;
using System.Collections;
using System.Collections.Generic;
//using System.Management.Instrumentation;
using UnityEngine;

public class IdleState : State
{
    protected D_IdleState stateData;

    //this bool is just in case we want enemies to idle but not flip after idle
    protected bool flipAfterIdle;
    protected bool isIdleTimeOver;

    protected bool isPlayerInMinAgroRange;

    protected float idleTime;

    public IdleState(Enemy entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(0f);
        isIdleTimeOver = false;
        setRandomIdleTime();

        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();

    }

    public override void Exit()
    {
        base.Exit();

        if (flipAfterIdle)
        {
            entity.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInMinAgroRange)
        {
            //shits not getting read
            stateMachine.ChangeState(entity.playerDetectedState);
        }
        else if(Time.time >= startTime + idleTime)
        {
            isIdleTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    public void SetFlipAfterIdle(bool flip)
    {
        flipAfterIdle = flip;
    }

    private void setRandomIdleTime()
    {
        //may need to switch this to System.Random.Range
        idleTime = UnityEngine.Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }
}
