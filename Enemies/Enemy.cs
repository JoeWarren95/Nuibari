using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase
{
    public Enemy_IdleState idleState { get; private set; }
    public Enemy_MoveState moveState { get; private set; }
    public Enemy_PlayerDetected playerDetectedState { get; private set; }

    //public Skirter_IdleState idleState { get; private set; }
    //public Skirter_MoveState moveState { get; private set; }
    //public Skirter_PlayerDetectedState playerDetectedState { get; private set; }
    //public Nymph_PlayerDetected playerDetectedState { get; private set; }
    //public Enemy_PlayerDetectedState playerDetectedState { get; private set; }


    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedData;


    public override void Start()
    {
        base.Start();

        moveState = new Enemy_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new Enemy_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new Enemy_PlayerDetected(this, stateMachine, "playerDetected", playerDetectedData, this);

        stateMachine.Initialize(moveState);
    }

}
