using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour {

  // Uses box collider on Pipe to increase score

	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
      

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.GetComponent<CageCon>())
        {
            col.gameObject.GetComponent<CageCon>().Score+=1;
        }
    }
}
