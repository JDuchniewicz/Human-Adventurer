using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class LevelManager : MonoBehaviour {


    public Text startText;
    public Text pressStart;
    public Text youWon;
    public Text tryAgain;
    GameObject player;
   public bool gameStarted = false;
   public bool won = false;
   public bool lost = false;

	// Use this for initialization
	void Start () {
        startText.enabled = true;
        pressStart.enabled = true;
        StartBlinking();
        youWon.enabled = false;
        tryAgain.enabled = false;
        player = GameObject.Find("Player");
        player.GetComponent<Movement>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (!gameStarted)
        {
            if (Input.anyKeyDown && !won && !lost)
            {
                pressStart.enabled = false;
                startText.enabled = false;
                player.GetComponent<Movement>().enabled = true;
                gameStarted = true;
                StopAllCoroutines();
            }
        }
        if (gameStarted && won)
        {
            youWon.enabled = true;
            pressStart.enabled = true;
            StartBlinking();
            player.GetComponent<Movement>().enabled = false;
            gameStarted = false;
        } 
        if(gameStarted && lost)
        {
            tryAgain.enabled = true;
            pressStart.enabled = true;
            StartBlinking();
            //disable sprite somewhere else
            player.GetComponent<Movement>().enabled = false;
            gameStarted = false;   
        }
        if (lost || won)
        {
            if (Input.anyKeyDown)
            {
                EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().name);
            }
        }
	}

    public IEnumerator BlinkText()
    {
        while (true)
        {
            pressStart.color = new Color32(0, 244, 255, 0);
            yield return new WaitForSeconds(.5f);
            pressStart.color = new Color32(0, 244, 255, 255);
            yield return new WaitForSeconds(.5f);
        }
    }

    void StartBlinking()
    {
        StopAllCoroutines();
        StartCoroutine("BlinkText");
    }

    void StopBlinking()
    {
        StopAllCoroutines();
    }
}
