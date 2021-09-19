using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float leftRewardSpeed = -5f;
    private Rigidbody2D enemyRigid;

    void Start()
    {
        enemyRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        enemyRigid.velocity = new Vector2(leftRewardSpeed, 0f);
    }
}