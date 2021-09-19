using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardScript : MonoBehaviour
{
    private float leftRewardSpeed = -5f;
    private Rigidbody2D rewardRigid;

    void Start()
    {
        rewardRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rewardRigid.velocity = new Vector2(leftRewardSpeed, 0f);
    }
}