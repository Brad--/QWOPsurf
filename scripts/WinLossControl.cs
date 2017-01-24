using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLossControl : MonoBehaviour {

    public GameObject player;
    public GameObject board;

    public float OffBoard;

	void Start () {
		
	}
	
	void Update () {
        // Out of bounds
        if(player.transform.position.x <= -15 || player.transform.position.x >= 15)
        {
            GameOver();
        }

        // Water
        if(player.transform.position.y <= 0)
        {
            // On the surfboard
            float distance = Vector2.Distance(player.transform.position,  board.transform.position);
            if(distance >= OffBoard)
            {
                GameOver();
            }
        }

        if(Input.GetKeyDown("l"))
        {
            GameOver();
        }
	}

    void GameOver()
    {
        // Stop Controller & Timer
        GetComponent<QWOPtroller>().gameOver = true;
        Timer timer = GameObject.Find("Main Camera").GetComponent<Timer>();
        timer.gameOver = true;

        // Hide Timer
        GameObject.Find("Timer").GetComponent<Text>().enabled = false;

        // Get Score / Display Game Over Text
        float score = timer.GetTimeElapsed();
        GameObject.Find("GameOver").GetComponent<Text>().text = "Game Over!\nYou lasted: " + timer.ToTime(score) +
            "\nPress SPACE to restart.";
    }

    void Victory()
    {
    }
}
