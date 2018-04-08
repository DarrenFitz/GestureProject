using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invader : MonoBehaviour {
    public float velocity = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position += new Vector3(0, -velocity * Time.deltaTime, 0);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ship") //collider tag Ship
        {
            gamefunction.Instance.MinusLife(); 
            Destroy(gameObject);
        }
        if (col.tag == "bullet") //bullet tag
        {
            Destroy(col.gameObject);
            gamefunction.Instance.AddScore(); //GameFunction AddScore()
            Destroy(gameObject); //Destroy Function
        }
    }
}
