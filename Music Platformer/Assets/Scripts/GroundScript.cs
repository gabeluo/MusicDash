using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private float leftSpeed = -5f;
    private Rigidbody2D groundRigid;
    private float yStart;
    public GameObject rewardPrefab;
    public GameObject enemyPrefab;
    private GameObject tempPrefab;

    void Start()
    {
        groundRigid = GetComponent<Rigidbody2D>();
        yStart = groundRigid.position.y;
    }

    void Update()
    {
        groundRigid.velocity = new Vector2(leftSpeed, 0f);
        // Respawn();
    }

    //void Respawn()
    //{
    //    if (transform.position.x < -11)
    //    {
    //        float ypos = Random.Range(yStart - 1f, yStart + 1f);
    //        float xpos = Random.Range(11.0f, 9.0f);
    //        transform.position = new Vector2(xpos, ypos);
    //        transform.localScale = new Vector2(5f, 5f);
    //        spawnEntities(xpos, ypos);
    //    }
    //}
}