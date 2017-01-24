using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    public float speed;

    public void SetStats(float speed)
    {
        this.speed = speed;
    }

	void Update () {
        Vector3 right = new Vector3(1, 0);
        this.transform.position += right * speed * Time.deltaTime;
	}

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);   
    }
}
