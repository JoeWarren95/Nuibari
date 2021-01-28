using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//should derive from the StateMachine

public class EnemyBase : MonoBehaviour
{
    public FiniteStateMachine stateMachine;

    public D_EnemyBase entityData;

    public int facingDirection { get; private set; }

    //what is every enemy going to do?
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public GameObject alive { get; private set; }

    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheck;
    [SerializeField]
    private Transform playerCheck;

    //going to change this value everytime we need to access it
    //instead of creating a new one each time
    private Vector2 velocityWork;


    public virtual void Start()
    {

        facingDirection = 1;

        alive = transform.Find("Alive").gameObject;
        //alive.GetComponent<Rigidbody2D>();
        rb = alive.GetComponent<Rigidbody2D>();
        anim = alive.GetComponent<Animator>();

        //SetVelocity(velocity);

        stateMachine = new FiniteStateMachine();

    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        //not set to an instance of an object
        velocityWork.Set(facingDirection * velocity, rb.velocity.y);
        rb.velocity = velocityWork;
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, alive.transform.right, entityData.wallCheckDist, entityData.whatIsGround);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDist, entityData.whatIsGround);
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, alive.transform.right, entityData.minAgroDist, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, alive.transform.right, entityData.maxAgroDist, entityData.whatIsPlayer);
    }


    public virtual void Flip()
    {
        facingDirection *= -1;
        alive.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDist));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDist));
        Gizmos.DrawLine(playerCheck.position, playerCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.minAgroDist));
    }

}
