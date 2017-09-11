using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Linq;

public class GameController : MonoBehaviour {

    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text coinsText;
    [SerializeField]
    Sprite healthFull;
    [SerializeField]
    Sprite healthHalf;
    [SerializeField]
    Sprite healthEmpty;
    List<Image> healthImagesList = new List<Image>();
    GameObject healthContainer;


    public float defaultHealthValue = 3;
   public float currentHealthValue = 0;
    int currentScore = 0;
    int coinNumber = 0;
	// Use this for initialization
	void Start () {
        currentHealthValue = defaultHealthValue;
        healthContainer = GameObject.Find("Life Remaining");
        foreach(Transform child in healthContainer.transform)
        {
            var im = child.GetComponent<Image>();
            if (im)
            {
                healthImagesList.Add(im);
            }
        }
        UpdateScore(0);
        AddCoins(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateScore(int amount)
    {
        currentScore += amount;
        string score = currentScore.ToString("D5"); 
        scoreText.text = "SCORE:" + score;
    }

   public void DeductScore(int amount)
    {
        currentScore -= amount;
        string score = currentScore.ToString("D5");
        scoreText.text = "SCORE:" + score;
    }

   public void AddCoins(int amount)
    {
        coinNumber += amount;
        string coins = coinNumber.ToString("D3");
        coinsText.text = "X" + coins;
    }

   public void AddHealth(float amount) //later add expanding health 
    {
       if((currentHealthValue+amount) <= defaultHealthValue) //change later
        {
            currentHealthValue += amount;
            ReDrawHealth();
        }
    }


   public void DeductHealth(float amount)
    {
        if((currentHealthValue-amount) <= 0)
        {
            currentHealthValue = 0;
            ReDrawHealth();
            //die externally - menu etc
        } else
        {
            currentHealthValue -= amount;
            ReDrawHealth();
            //do it so appropriate amount of hearts is redrawn 
        }
    }


    void ReDrawHealth()
    {
        int drawCount = 0;
        //redraw appropriate amount of hearts;
        //draw full ones
        int fulls = Mathf.FloorToInt(currentHealthValue);
        int empties = Mathf.FloorToInt(defaultHealthValue - currentHealthValue);


        for (int i = 0; i < fulls; i++, drawCount++)
        {
            healthImagesList[drawCount].sprite = healthFull;
        }
        //draw half if there is one
        if ((currentHealthValue - fulls) > 0)
        {
            healthImagesList[drawCount].sprite = healthHalf;
            drawCount++;
        }
        //draw empties
        for (int i = 0; i < empties; i++, drawCount++)
        {
            healthImagesList[drawCount].sprite = healthEmpty;
        }
    }

}
