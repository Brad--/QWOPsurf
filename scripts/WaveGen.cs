using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGen : MonoBehaviour {

    public Sprite wave;
    public Sprite backgroundWave;
    public Sprite backgroundWave2;
    public Sprite backgroundWave3;

    public float DebugSize = 1;
    public float DebugSpeed = 10;
    public float yMod;

    public float BackgroundSpeed;

    public float WaveDensity = 3;

    public float WaveWidth;
    public float startX;
    public float endX;

    private List<GameObject> waves;
    private Timer timer;

	void Start () {
        timer = GameObject.Find("Main Camera").GetComponent<Timer>();

        SendBackgroundWave(backgroundWave, startX, BackgroundSpeed, -yMod, 0);
        SendBackgroundWave(backgroundWave2, startX - 3, BackgroundSpeed - 1, yMod, 0);
        SendBackgroundWave(backgroundWave3, startX - 3, BackgroundSpeed - 2, yMod + .5f, 0);
        SendBackgroundWave(backgroundWave2, startX, BackgroundSpeed, -yMod, 999);
    }

    void SendBackgroundWave(Sprite sprite, float x, float speed, float y, int sortOrder)
    {
        float length = x;
        while (length <= endX)
        {
            // Create new wave at appropriate position
            GameObject newWave = new GameObject();
            newWave.name = "Background Wave";
            newWave.transform.position = new Vector2(length, -10.05f + y);
            length += WaveWidth;

            // Render wave
            SpriteRenderer renderer = newWave.AddComponent<SpriteRenderer>();
            renderer.sprite = sprite;
            renderer.sortingOrder = sortOrder;

            // Send it off
            BackgroundWaveController controller = newWave.AddComponent<BackgroundWaveController>();
            controller.SetupWave(x, endX, speed);
        }
    }
    
    void Update() {
        // For debug
        if (Input.GetKeyDown("z"))
        {
            SendWave(DebugSize, DebugSpeed);
        }

        float timeElapsed = timer.GetTimeElapsed();
        float chance = .1f;
        
        if(timeElapsed > 120)
        {
            chance = .8f;
        }
        else if(timeElapsed > 90)
        {
            chance = .6f;
        }
        else if(timeElapsed > 60)
        {
            chance = .4f;
        }
        else if(timeElapsed > 30)
        {
            chance = .2f;
        }

        chance /= 10;

        float waveSize = DebugSize;
        float waveSpeed = DebugSpeed;

        if(Random.value <= chance)
        {
            SendWave(waveSize, waveSpeed);
        }
	}

    void SendWave(float size, float speed)
    {
        // Wave gameobject
        GameObject newWave = new GameObject();
        newWave.name = "Attack Wave";
        newWave.transform.position = GameObject.Find("WaveGen").transform.position + new Vector3(0, -size * 8f, 0);

        // Add Buoyancy & Collider
        AreaEffector2D effector = newWave.AddComponent<AreaEffector2D>();
        effector.forceAngle = 90;
        //effector.forceMagnitude = 100 * size;
        BoxCollider2D collider = newWave.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;
        collider.usedByEffector = true;
        collider.size = new Vector2(size * 100, size * 200);

        // Render wave
        SpriteRenderer renderer = newWave.AddComponent<SpriteRenderer>();
        renderer.sprite = wave;
        renderer.sortingOrder = 99999;

        // Create wave controller
        WaveController controller = newWave.AddComponent<WaveController>();
        newWave.transform.localScale = new Vector3(size, size, size);

        // Send the wave
        controller.SetStats(speed);
    }
}
