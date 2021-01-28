using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this adds a menu tab when we right click in the project
[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]

public class D_EnemyBase : ScriptableObject
{
    public float wallCheckDist = 0.2f;
    public float ledgeCheckDist = 0.4f;

    public float minAgroDist = 3f;
    public float maxAgroDist = 4f;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer; 
}
