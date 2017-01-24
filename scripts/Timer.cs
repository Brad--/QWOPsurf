using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timer = 300;
    public bool gameOver = false;

    private float timeElapsed;
    private Text text;


	void Start () {
        text = GameObject.Find("Timer").GetComponent<Text>();
        timeElapsed = 0;	
	}
	
	void Update () {
        if (!gameOver)
        {
            timeElapsed += Time.deltaTime;
            text.text = ToTime(timer - timeElapsed);
        }
	}

    public float GetTimeElapsed()
    {
        return timeElapsed;
    }

    public string ToTime(float num)
    {
        int asInt = (int)num;
        int minutes = asInt / 60;
        asInt -= 60 * minutes;

        // Format single digit minutes as 0:00
        return asInt < 10 ? minutes + ":0" + asInt : minutes + ":" + asInt;
    }
}
