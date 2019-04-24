using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour {

   

    public float speed;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x > -116 && PopeGenerator.singleton.bIsStarted == true)
            transform.position += new Vector3(-(Time.deltaTime * speed), 0, 0);

        else if(transform.position.x <= -116 && PopeGenerator.singleton.bIsStarted == true)
        {
            transform.position = new Vector3(116.0f, transform.position.y, transform.position.z);
        }
      
    }
}
