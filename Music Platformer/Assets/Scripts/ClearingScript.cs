using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearingScript : MonoBehaviour
{
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var clones = GameObject.FindGameObjectsWithTag("Enemy");
        var clones2 = GameObject.FindGameObjectsWithTag("Ground");
        var clones3 = GameObject.FindGameObjectsWithTag("Reward");
        foreach (var clone in clones)
        {
            if (clone.transform.position.x < -12)
                Destroy(clone);
        }
        foreach (var clone in clones2)
        {
            if (clone.transform.position.x < -12)
                Destroy(clone);
        }
        foreach (var clone in clones3)
        {
            if (clone.transform.position.x < -12)
                Destroy(clone);
        }
    }
}
