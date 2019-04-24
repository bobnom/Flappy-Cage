using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopeMovement : MonoBehaviour {

    public bool isStarted;
    public static bool canMove = true;
    public float movespeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isStarted && canMove)
            gameObject.transform.position += new Vector3(-movespeed, 0, 0);
    }
}
