using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    GameObject Player;
    public GameObject groundPrefab;
    public Text scoreText;
    public int score = 3;

    void Start()
    {
        Instantiate(groundPrefab, new Vector3(7, 0, 0), Quaternion.identity);
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
}