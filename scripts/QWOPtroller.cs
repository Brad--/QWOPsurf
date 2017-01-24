using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QWOPtroller : MonoBehaviour {

    public float force;
    public bool gameOver = false;

	void Start () {
        gameOver = false;
	}
	
	void Update () {
        if (!gameOver)
        {
            if (Input.GetKeyDown("q"))
            {
                GameObject uLeg = GameObject.Find("UpperLeg");
                uLeg.GetComponent<Rigidbody2D>().velocity += new Vector2(-force, 0);
            }
            if (Input.GetKeyDown("w"))
            {
                GameObject lLeg = GameObject.Find("UpperLegBack");
                lLeg.GetComponent<Rigidbody2D>().velocity += new Vector2(force, 0);
            }

            if (Input.GetKeyDown("o"))
            {
                GameObject lLeg = GameObject.Find("LowerLeg");
                lLeg.GetComponent<Rigidbody2D>().velocity += new Vector2(-force, 0);
            }
            if (Input.GetKeyDown("p"))
            {
                GameObject lLegBack = GameObject.Find("LowerLegBack");
                lLegBack.GetComponent<Rigidbody2D>().velocity += new Vector2(force, 0);
            }
        } 
        else
        {
            if(Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }



        // ********************************************
        // ********************************************
        // ********************************************
        // DONT FORGET TO CHANGE THIS
        // ********************************************
        // ********************************************
        // ********************************************
        if (Input.GetKeyDown("b"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
