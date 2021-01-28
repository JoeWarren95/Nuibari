﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    protected FiniteStateMachine stateMachine;
    protected Enemy entity;

    protected float startTime;

    protected string animBoolName;


    //need constructor
    public State(Enemy entity, FiniteStateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }


    public virtual void Enter()
    {
        //may need deltatime here
        startTime = Time.time;
        entity.anim.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        entity.anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }
}
