using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pope : MonoBehaviour {

    public static bool canMove = true;

    public float movespeed;

    public bool isStarted = false;

    float timer = 0, lifeLen = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
     

        timer += Time.deltaTime;
        if(timer > lifeLen && canMove)
        {
            Destroy(transform.parent.gameObject);
        }
	}
}
