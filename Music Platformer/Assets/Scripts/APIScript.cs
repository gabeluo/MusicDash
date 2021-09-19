using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using System.Threading.Tasks;
using SpotifyAPI.Web;

public class APIScript : MonoBehaviour
{

    public AudioSource audioSource = null;
    private GameObject tempPrefab;
    public GameObject rewardPrefab;
    public GameObject enemyPrefab;
    public GameObject groundPrefab;
    public Text winText;
    GameObject Quit;
    GameObject Clearing;

    private SpotifyAPI.Web.TrackAudioAnalysis track = null;
    // Start is called before the first frame update

    void Start()
    {
        Quit = GameObject.Find("QuitButton");
        Clearing = GameObject.Find("BoardClearing");
        StartCoroutine(getTimingData());
    }

    async void callAPI()
    {
        var spotify = new SpotifyClient("BQCCrwd343rDrhRu7-Hkhr19VEuFkkkXetDWRCRzPiuFMOGeAnlsZMPfyLQMro6VLlMiiUHBEbSzk5SPyUzDAsJO2MNfCQK_6ilfTYt7D4xzmCYGW4v51xPi2vH7Fk-t6JQYfWCt7tB8mP2bZ5WEaxs_6OSdtCmz1KM");

        track = await spotify.Tracks.GetAudioAnalysis("2RlgNHKcydI9sayD2Df2xp");
    }

    IEnumerator getTimingData()
    {
        var taskYieldInstruction = Task.Run(() => callAPI());
        yield return new WaitForSeconds(1.5f);
;       yield return taskYieldInstruction;

        audioSource.Play();
        var flag = false;
        for (int i = 0; i <= track.Bars.Count - 1; i = i + 1)
        {
            if (Clearing.GetComponent<ClearingScript>().gameOver)
            {
                Quit.SetActive(true);
                flag = true;
                break;
            }
            float xscale = UnityEngine.Random.Range(0f, 5f);
            float ypos = UnityEngine.Random.Range(0f - 1.5f, 0f + 1.5f);
            Instantiate(groundPrefab, new Vector3(9f, ypos, 0), Quaternion.identity);
            spawnEntities(9f, ypos);
            yield return new WaitForSeconds(track.Bars[i].Duration);
        }
        Quit.SetActive(true);
        if (!flag)
        {
            winText.text = "YOU WIN";
        }
    }

    void spawnEntities(float xpos, float ypos)
    {
        // Destroy(tempPrefab);
        float xposition = UnityEngine.Random.Range(-1.0f, 1.25f);
        int rewardChance = UnityEngine.Random.Range(1, 4);
        Debug.Log(rewardChance);
        int enemyChance = UnityEngine.Random.Range(1, 3);
        if (rewardChance > 2)
        {
            tempPrefab = Instantiate(rewardPrefab, new Vector3(xpos - xposition, ypos + 0.75f, 0), Quaternion.identity);
        }
        else if (enemyChance > 1)
        {
            tempPrefab = Instantiate(enemyPrefab, new Vector3(xpos + xposition, ypos + 0.71f, 0), Quaternion.identity);
        }
    }
}
