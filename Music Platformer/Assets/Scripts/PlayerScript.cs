using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using System.Threading.Tasks;
using SpotifyAPI.Web;

public class PlayerScript : MonoBehaviour
{
    private float moveSpeed = 7.5f;
    private float jumpHeight = 12f;
    public bool onPlatform = true;
    private int notVisibleCount = 0;
    GameObject MainCanvas;
    GameObject Clearing;
    public Text gameOverText;

    void Start()
    {
        Clearing = GameObject.Find("BoardClearing");
        MainCanvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;
        GameOver();
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && onPlatform)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce
                (new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
            onPlatform = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Reward")
        {
            collision.gameObject.transform.position = new Vector2(100, 100);
            Destroy(collision.gameObject);
            MainCanvas.GetComponent<CanvasScript>().score++;
            MainCanvas.GetComponent<CanvasScript>().UpdateScore();
        }
        else if (collision.collider.tag == "Enemy")
        {
            collision.gameObject.transform.position = new Vector2(100, 100);
            Destroy(collision.gameObject);
            MainCanvas.GetComponent<CanvasScript>().score--;
            MainCanvas.GetComponent<CanvasScript>().UpdateScore();

        }
    }

    void GameOver()
    {
        if (!(GetComponent<Renderer>().isVisible))
        {
            notVisibleCount++;
        }
        if (notVisibleCount > 45)
        {
            var clones = GameObject.FindGameObjectsWithTag("Enemy");
            var clones2 = GameObject.FindGameObjectsWithTag("Ground");
            var clones3 = GameObject.FindGameObjectsWithTag("Reward");
            foreach (var clone in clones)
            {
                Destroy(clone);
            }
            foreach (var clone in clones2)
            {
                Destroy(clone);
            }
            foreach (var clone in clones3)
            {
                Destroy(clone);
            }
            Clearing.GetComponent<ClearingScript>().gameOver = true;
            Destroy(gameObject);
            gameOverText.text = "GAME OVER";
        }
        if (MainCanvas.GetComponent<CanvasScript>().score == 0)
        {
            var clones = GameObject.FindGameObjectsWithTag("Enemy");
            var clones2 = GameObject.FindGameObjectsWithTag("Ground");
            var clones3 = GameObject.FindGameObjectsWithTag("Reward");
            foreach (var clone in clones)
            {
                Destroy(clone);
            }
            foreach (var clone in clones2)
            {
                Destroy(clone);
            }
            foreach (var clone in clones3)
            {
                Destroy(clone);
            }
            Clearing.GetComponent<ClearingScript>().gameOver = true;
            Destroy(gameObject);
            gameOverText.text = "GAME OVER";
        }
    }
}