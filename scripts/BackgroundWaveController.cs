using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundWaveController : MonoBehaviour {
    public float speed;

    private float startX, endX;
	void Start () {
	}

    public void SetupWave(float startX, float endX, float speed)
    {
        this.speed = speed;
        this.endX = endX;
        this.startX = startX;
    }
	
	void Update () {
        if (this.transform.position.x >= endX)
        {
            this.transform.position = new Vector2(startX, this.transform.position.y);
        }

        Vector3 right = new Vector3(1, 0);
        this.transform.position += right * speed * Time.deltaTime;
    }
}
