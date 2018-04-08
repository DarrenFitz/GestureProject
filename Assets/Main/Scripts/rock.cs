using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour {
    public float velocity = 1f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position += new Vector3(0, -velocity * Time.deltaTime, 0);
    }
    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.tag == "ship")
        {
            gamefunction.Instance.MinusLife();
            Destroy(gameObject); 
        }
    }
}
